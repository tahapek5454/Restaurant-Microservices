namespace Restaurant.Integration.Application.Events.EmailEvents;

public class EmailSendStartedEvent
{
    public Guid Id { get; set; }
    public string To { get; set; }
    public string Payload { get; set; }
}

