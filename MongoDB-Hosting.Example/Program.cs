using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB_Hosting.Example;

var builder = Host.CreateDefaultBuilder();
builder.ConfigureServices(services =>
{
    services.AddMongoService("YourMongoUri");
    services.AddSingleton<Random>();

    services.AddHostedService<ExampleService>();
});

builder.Build().Run();
