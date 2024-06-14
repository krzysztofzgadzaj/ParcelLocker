using MassTransit;
using OutPost.Modules.Commission.Application.Events.Internal;

namespace OutPost.Modules.Commission.Application.BackgroundProcessing.Sagas.CommissionValidation;

public class ValidationSaga : MassTransitStateMachine<ValidationSagaInstance>
{
    public ValidationSaga()
    {
        Event(
            () => CommissionCreatedEvent, 
            x => x.CorrelateById(context => context.Message.CommissionId));
        
        Event(
            () => CommissionPaidEvent, 
            x => x.CorrelateById(context => context.Message.CommissionId));
        
        Initially(
            When(CommissionCreatedEvent)
                .Activity(x => x.OfType<ValidateCommissionActivity>())
                .TransitionTo(Submitted));
        
        During(Submitted, 
            When(CommissionPaidEvent)
                .TransitionTo(Completed));
    }
    
    public State Submitted { get; set; }
    public State Completed { get; set; }
    public Event<CommissionCreatedEvent> CommissionCreatedEvent { get; private set; }
    public Event<CommissionPaidEvent> CommissionPaidEvent { get; private set; }
}
