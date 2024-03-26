using MassTransit;

namespace Orchestration.Service.StateInstances;

public class EmailStateInstance : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public string CurrentState { get; set; }

    public Guid Id { get; set; }
    public string To { get; set; }
    public string Payload { get; set; }
}

