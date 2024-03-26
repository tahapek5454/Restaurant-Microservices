

namespace Restaurant.Integration.Application.RabbitSettings
{
    public static class QueueNames
    {
        public static readonly string Email_EmaiilSendEventQueue = "email_email_send_event_queue";
        public static readonly string EmaiilStateMachineQueue = "email_state_machine_queue";
    }
}
