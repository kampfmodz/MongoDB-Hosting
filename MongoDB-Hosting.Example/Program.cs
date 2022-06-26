using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB_Hosting.Example;

var builder = Host.CreateDefaultBuilder();
builder.ConfigureServices(services =>
{
    services.AddMongoService("mongodb://kampfmodz:lukas1707@localhost:27017/test?authSource=admin&readPreference=primary&appname=MongoDB%20Compass&ssl=false");
    services.AddSingleton<Random>();

    services.AddHostedService<ExampleService>();
});

builder.Build().Run();