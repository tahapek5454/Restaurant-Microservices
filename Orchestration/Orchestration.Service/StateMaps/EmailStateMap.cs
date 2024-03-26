using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orchestration.Service.StateInstances;

namespace Orchestration.Service.StateMaps;

public class EmailStateMap: SagaClassMap<EmailStateInstance>
{
    protected override void Configure(EntityTypeBuilder<EmailStateInstance> entity, ModelBuilder model)
    {
        entity.Property(x => x.To).IsRequired();
        entity.Property(x => x.Payload).IsRequired();
    }

}

