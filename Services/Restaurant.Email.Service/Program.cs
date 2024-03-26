using MassTransit;
using Restaurant.Email.Service.Consumers;
using Restaurant.Integration.Application.RabbitSettings;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMassTransit(configure =>
{

    configure.AddConsumer<EmailSendEventConsumer>();

    configure.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(builder.Configuration.GetConnectionString("RabbitMQ"));

        configurator.ReceiveEndpoint(QueueNames.Email_EmaiilSendEventQueue, e =>
        {
            e.ConfigureConsumer<EmailSendEventConsumer>(context);
            e.DiscardSkippedMessages();
        });
    });
});

var host = builder.Build();
host.Run();
