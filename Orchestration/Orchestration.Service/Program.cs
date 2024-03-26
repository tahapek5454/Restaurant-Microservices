

using MassTransit;
using Microsoft.EntityFrameworkCore;
using Orchestration.Service.StateDbContexts;
using Orchestration.Service.StateInstances;
using Orchestration.Service.StateMachines;
using Restaurant.Integration.Application.RabbitSettings;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMassTransit(configure =>
{
    configure.AddSagaStateMachine<EmailStateMachine, EmailStateInstance>()
    .EntityFrameworkRepository(options =>
    {
        options.AddDbContext<DbContext, RestaurantStateDbContext>((provider, _builder) =>
        {
            _builder.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"));
        });
    });

    configure.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(builder.Configuration.GetConnectionString("RabbitMQ"));

        configurator.ReceiveEndpoint(QueueNames.EmaiilStateMachineQueue, e =>
        {
            e.ConfigureSaga<EmailStateInstance>(context);
            e.DiscardSkippedMessages();
        });
    });

});

void ApplyPendigMigration()
{
    var _db = builder.Services.BuildServiceProvider().GetRequiredService<DbContext>();

    if (_db.Database.GetPendingMigrations().Count() > 0)
        _db.Database.Migrate();
}

var host = builder.Build();

ApplyPendigMigration();

host.Run();
