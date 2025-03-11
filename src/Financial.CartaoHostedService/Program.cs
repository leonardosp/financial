using Financial.CartaoHostedService;
using Financial.Cross.Message.DI;
using Financial.Cross.Utils;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddMessageBus(builder.Configuration.GetMessageQueueConnection("MessageBus"));
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
