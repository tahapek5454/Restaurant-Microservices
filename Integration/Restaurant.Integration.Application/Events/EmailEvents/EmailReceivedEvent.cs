
using MassTransit;

namespace Restaurant.Integration.Application.Events.EmailEvents
{
    public class EmailReceivedEvent : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; }

        public EmailReceivedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
    }
}
