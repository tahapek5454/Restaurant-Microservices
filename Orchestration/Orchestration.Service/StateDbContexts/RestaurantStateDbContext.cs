
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Orchestration.Service.StateMaps;

namespace Orchestration.Service.StateDbContexts;

public class RestaurantStateDbContext : SagaDbContext
{
    public RestaurantStateDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override IEnumerable<ISagaClassMap> Configurations
    {
        get
        {
            yield return new EmailStateMap(); 
        }
    }
}

