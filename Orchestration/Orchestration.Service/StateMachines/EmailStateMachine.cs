
using MassTransit;
using Orchestration.Service.StateInstances;
using Restaurant.Integration.Application.Events.EmailEvents;
using Restaurant.Integration.Application.RabbitSettings;

namespace Orchestration.Service.StateMachines;

public class EmailStateMachine: MassTransitStateMachine<EmailStateInstance>
{
    public Event<EmailSendStartedEvent> EmailSendStartedEvent { get; set; }
    public Event<EmailReceivedEvent> EmailReceivedEvent { get; set; }

    public State EmailSend { get; set; }
    public State EmailReceived { get; set; }

    public EmailStateMachine()
    {
        InstanceState(instance => instance.CurrentState);

        Event(() => EmailSendStartedEvent, (instance) =>
        {
            instance.CorrelateBy<Guid>(database => database.Id, @event => @event.Message.Id)
            .SelectId(e => Guid.NewGuid());
        });

        Event(() => EmailReceivedEvent, (instance) =>
        {
            instance.CorrelateById(@event => @event.Message.CorrelationId);
        });


        Initially(

                When(EmailSendStartedEvent)
                .Then(context =>
                {
                    context.Instance.Id = context.Data.Id;
                    context.Instance.Payload = context.Data.Payload;
                    context.Instance.To = context.Data.To;

                })
                .TransitionTo(EmailSend)
                .Send(new Uri($"queue:{QueueNames.Email_EmaiilSendEventQueue}"), context => new EmailSendEvent(context.Instance.CorrelationId)
                {
                    Id = context.Data.Id,
                    Payload = context.Data.Payload,
                    To = context.Data.To

                })
            );

        During(
                EmailSend,
                When(EmailReceivedEvent)
                .TransitionTo(EmailReceived)
                .Finalize()
            );

        SetCompletedWhenFinalized();
    }
}

