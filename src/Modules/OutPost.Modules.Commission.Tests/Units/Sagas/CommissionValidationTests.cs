using System.Diagnostics;
using FluentAssertions;
using MassTransit;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using OutPost.Modules.Commission.Application.BackgroundProcessing.Sagas.CommissionValidation;
using OutPost.Modules.Commission.Application.Clients.LogisticsClient;
using OutPost.Modules.Commission.Application.Events.Internal;
using OutPost.Modules.Commission.Domain;
using OutPost.Modules.Commission.Domain.DeliveryMethods;
using OutPost.Modules.Commission.Domain.Repositories;
using OutPost.Shared.Abstractions.Localization;
using Xunit;

namespace OutPost.Modules.Commission.Tests.Units.Sagas;

public class CommissionValidationTests : IAsyncLifetime
{
    private readonly Mock<ICommissionRepository> _commissionRepositoryMock = new ();
    private readonly Mock<ILogisticsClient> _logisticsClientMock = new ();
    private ITestHarness _testHarness;
    private IServiceProvider _serviceProvider;

    public async Task InitializeAsync()
    {
        _serviceProvider = new ServiceCollection()
            .AddMassTransitTestHarness(cfg =>
            {
                cfg.AddSagaStateMachine<ValidationSaga, ValidationSagaInstance>();
                cfg.SetTestTimeouts(testInactivityTimeout: Debugger.IsAttached
                    ? TimeSpan.FromSeconds(10)
                    : TimeSpan.FromSeconds(1));
            })
            .AddScoped<ValidateCommissionActivity>(x =>
                new ValidateCommissionActivity(_commissionRepositoryMock.Object, _logisticsClientMock.Object))
            .BuildServiceProvider(true);
        
        _testHarness = _serviceProvider.GetRequiredService<ITestHarness>();

        await _testHarness.Start();
    }

    public async Task DisposeAsync()
    {
        await _testHarness.Stop();
    }

    [Fact]
    public async Task ASampleTest()
    {
        var sagaId = Guid.NewGuid();

        await _testHarness.Bus.Publish(new CommissionCreatedEvent(sagaId));
        
        Assert.True(await _testHarness.Consumed.Any<CommissionCreatedEvent>());

        var sagaHarness = _testHarness.GetSagaStateMachineHarness<ValidationSaga, ValidationSagaInstance>();

        Assert.True(await sagaHarness.Consumed.Any<CommissionCreatedEvent>());

        Assert.True(await sagaHarness.Created.Any(x => x.CorrelationId == sagaId));

        var instance = sagaHarness.Created.ContainsInState(sagaId, sagaHarness.StateMachine, sagaHarness.StateMachine.Submitted);
        Assert.NotNull(instance);
        
        _commissionRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
    }
    
    [Fact]
    public async Task Commission_successfully_validated_when_mdp_reservation_works()
    {
        // Arrange
        var commissionId = Guid.NewGuid();
        _commissionRepositoryMock
            .Setup(x => x.GetByIdAsync(It.Is<Guid>(y => y == commissionId)))
            .ReturnsAsync(CreateCommission());
            
        // Act
        await _testHarness.Bus.Publish(new CommissionCreatedEvent(commissionId));

        // Assert
        Assert.True(await _testHarness.Consumed.Any<CommissionCreatedEvent>());
        _logisticsClientMock.Verify(x => x.ReserveForClient(It.IsAny<Guid>(), It.IsAny<Guid>()), Times.AtLeastOnce);

        var sagaHarness = _testHarness.GetSagaStateMachineHarness<ValidationSaga, ValidationSagaInstance>();
        var instance = sagaHarness.Created.ContainsInState(commissionId, sagaHarness.StateMachine, sagaHarness.StateMachine.Submitted);
        instance.CurrentState.Name.Should().Be(nameof(ValidationSaga.Submitted));
    }
    
    [Fact]
    public async Task Submission_created_when_mdp_validation_and_payment_succeeded()
    {
        // Arrange
        var commission = CreateCommission();
        _commissionRepositoryMock.Setup(x => x.GetByIdAsync(It.Is<Guid>(y => y == commission.Id)))
            .ReturnsAsync(commission);
        
        // Act
        await _testHarness.Bus.Publish(new CommissionCreatedEvent(commission.Id));
        await _testHarness.Bus.Publish(new CommissionPaidEvent(commission.Id));

        // Assert
        Assert.True(await _testHarness.Consumed.Any<CommissionCreatedEvent>());
        Assert.True(await _testHarness.Consumed.Any<CommissionPaidEvent>());
        _logisticsClientMock.Verify(x => x.ReserveForClient(It.IsAny<Guid>(), It.IsAny<Guid>()), Times.Once);
        _logisticsClientMock.Verify(x => x.CreateSubmission(), Times.Once);

        var sagaHarness = _testHarness.GetSagaStateMachineHarness<ValidationSaga, ValidationSagaInstance>();
        var instance = sagaHarness.Created.ContainsInState(commission.Id, sagaHarness.StateMachine, sagaHarness.StateMachine.Submitted);
        instance.CurrentState.Name.Should().Be(nameof(ValidationSaga.Completed));
        commission.Status.Should().Be(CommissionStatus.Completed);
    }
    
    [Fact]
    public async Task Commission_invalidated_when_mdp_has_no_place_and_payment_was_not_processed_yet()
    {
        // Arrange
        var commission = CreateCommission();
        _commissionRepositoryMock.Setup(x => x.GetByIdAsync(It.Is<Guid>(y => y == commission.Id)))
            .ReturnsAsync(commission);
        
        _logisticsClientMock.Setup(x => x.ReserveForClient(It.IsAny<Guid>(), It.IsAny<Guid>())).ThrowsAsync(new TempException("siema"));

        // Act
        await _testHarness.Bus.Publish(new CommissionCreatedEvent(commission.Id));

        // Assert
        Assert.True(await _testHarness.Consumed.Any<CommissionCreatedEvent>());
        _logisticsClientMock.Verify(x => x.ReserveForClient(It.IsAny<Guid>(), It.IsAny<Guid>()), Times.AtLeastOnce);

        var sagaHarness = _testHarness.GetSagaStateMachineHarness<ValidationSaga, ValidationSagaInstance>();
        var instance = sagaHarness.Created.ContainsInState(commission.Id, sagaHarness.StateMachine, sagaHarness.StateMachine.Submitted);
        instance.CurrentState.Name.Should().Be(nameof(ValidationSaga.Completed));
        commission.Status.Should().Be(CommissionStatus.Retired);
    }
    
    [Fact]
    public async Task Mdp_changed_when_commission_paid_and_validation_did_not_pass()
    {
        // Arrange
        var commission = CreateCommission();
        _commissionRepositoryMock.Setup(x => x.GetByIdAsync(It.Is<Guid>(y => y == commission.Id)))
            .ReturnsAsync(commission);
        
        _logisticsClientMock.Setup(x 
                => x.ReserveForClient(It.IsAny<Guid>(), It.IsAny<Guid>()))
            .Callback(async () => await Task.Delay(3000));
        
        // Act
        await _testHarness.Bus.Publish(new CommissionCreatedEvent(commission.Id));
        await _testHarness.Bus.Publish(new CommissionPaidEvent(commission.Id));
        await Task.Delay(3000);

        // Assert
        Assert.True(await _testHarness.Consumed.Any<CommissionCreatedEvent>());
        Assert.True(await _testHarness.Consumed.Any<CommissionPaidEvent>());
        _logisticsClientMock.Verify(x => x.ReserveForClient(It.IsAny<Guid>(), It.IsAny<Guid>()), Times.AtLeastOnce);
        _logisticsClientMock.Verify(x => x.ReserveClosestMdp(It.IsAny<Guid>(), It.IsAny<Guid>()), Times.AtLeastOnce);
        _logisticsClientMock.Verify(x => x.CreateSubmission(), Times.AtLeastOnce);

        var sagaHarness = _testHarness.GetSagaStateMachineHarness<ValidationSaga, ValidationSagaInstance>();
        var instance = sagaHarness.Created.ContainsInState(commission.Id, sagaHarness.StateMachine, sagaHarness.StateMachine.Submitted);
        instance.CurrentState.Name.Should().Be(nameof(ValidationSaga.Completed));
        commission.Status.Should().Be(CommissionStatus.Completed);
    }
    
    private static DirectDeliveryMethod CreateDirectDeliveryMethod(string address = "address") 
        => new(new Address(address));
    
    private static MdpDeliveryMethod CreateMdpDeliveryMethod(Guid? id = null, decimal markup = 10) 
        => new(new Mdp(id ?? Guid.NewGuid(), markup));
    
    private static ParcelParameters CreateParcelParameters(double height = 10, 
        double width = 10, 
        double length = 10,
        double weight = 10) 
        => new(height, width, length, weight);

    private static Domain.Commission CreateCommission(
        ParcelParameters? parcelParameters = null,
        DeliveryMethod? parcelStartingPoint = null,
        DeliveryMethod? parcelDeliveryPoint = null,
        decimal? outpostMarkup = null)
    {
        var parcel = parcelParameters ?? CreateParcelParameters();
        var startingPoint = parcelStartingPoint ?? CreateDirectDeliveryMethod();
        var deliveryPoint = parcelDeliveryPoint ?? CreateMdpDeliveryMethod();
        var outpostMarkupValue = outpostMarkup ?? 10;
        
        return Domain.Commission.CreateCommission(parcel, 
            startingPoint, 
            deliveryPoint,
            outpostMarkupValue);
    }
}
