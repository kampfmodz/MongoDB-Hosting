using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB_Hosting.Example;
using MongoDBHosting;

var builder = Host.CreateDefaultBuilder();
builder.ConfigureServices(services =>
{
    services.AddMongoService("mongodb://localhost:27017/");
    services.AddSingleton<Random>();

    services.AddHostedService<ExampleService>();
});

builder.Build().Run();
