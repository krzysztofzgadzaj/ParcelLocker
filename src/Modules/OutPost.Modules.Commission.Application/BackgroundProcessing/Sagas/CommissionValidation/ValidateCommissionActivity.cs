using MassTransit;
using OutPost.Modules.Commission.Application.Clients.LogisticsClient;
using OutPost.Modules.Commission.Application.Events.Internal;
using OutPost.Modules.Commission.Domain.Repositories;

namespace OutPost.Modules.Commission.Application.BackgroundProcessing.Sagas.CommissionValidation;

public class ValidateCommissionActivity
    : IStateMachineActivity<ValidationSagaInstance, CommissionCreatedEvent>
{
    private readonly ICommissionRepository _commissionRepository;
    private readonly ILogisticsClient _logisticsClient;

    public ValidateCommissionActivity(ICommissionRepository commissionRepository, ILogisticsClient logisticsClient)
    {
        _commissionRepository = commissionRepository;
        _logisticsClient = logisticsClient;
    }

    public async Task Execute(BehaviorContext<ValidationSagaInstance, CommissionCreatedEvent> context, 
        IBehavior<ValidationSagaInstance, CommissionCreatedEvent> next)
    {
        var commission = await _commissionRepository.GetByIdAsync(context.Message.CommissionId);
        await _logisticsClient.ReserveForClient(Guid.NewGuid(), context.Message.CommissionId);
        commission.MarkAsValidated();
        await _commissionRepository.UpdateAsync(commission);
        await next.Execute(context).ConfigureAwait(false);
    }

    public Task Faulted<TException>(BehaviorExceptionContext<ValidationSagaInstance, CommissionCreatedEvent, TException> context, IBehavior<ValidationSagaInstance, CommissionCreatedEvent> next) where TException : Exception
    {
        return next.Faulted(context);
    }
    
    public void Probe(ProbeContext context)
    {
        context.CreateScope("commission-created");
    }

    public void Accept(StateMachineVisitor visitor)
    {
        visitor.Visit(this);
    }
}
