using MassTransit;
using Restaurant.Integration.Application.Events.EmailEvents;
using Restaurant.Integration.Application.RabbitSettings;

namespace Restaurant.Email.Service.Consumers
{
    public class EmailSendEventConsumer(ISendEndpointProvider _sendEndpointProvider) : IConsumer<EmailSendEvent>
    {
        public async Task Consume(ConsumeContext<EmailSendEvent> context)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(context.Message.To);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{QueueNames.EmaiilStateMachineQueue}"));

            await sendEndpoint.Send<EmailReceivedEvent>(new(context.Message.CorrelationId));

        }
    }
}
