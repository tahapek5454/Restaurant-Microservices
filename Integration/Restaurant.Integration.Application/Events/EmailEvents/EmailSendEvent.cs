using MassTransit;

namespace Restaurant.Integration.Application.Events.EmailEvents
{
    public class EmailSendEvent : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; }

        public EmailSendEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public Guid Id { get; set; }
        public string To { get; set; }
        public string Payload { get; set; }
    }
}
