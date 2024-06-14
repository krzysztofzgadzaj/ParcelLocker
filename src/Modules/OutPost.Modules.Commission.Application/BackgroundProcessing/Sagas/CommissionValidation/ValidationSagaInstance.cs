using MassTransit;

namespace OutPost.Modules.Commission.Application.BackgroundProcessing.Sagas.CommissionValidation;

public class ValidationSagaInstance : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public State CurrentState { get; set; }
}
