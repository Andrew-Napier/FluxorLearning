// See https://aka.ms/new-console-template for more information

using Fluxor;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, Fluxor!");

var services = new ServiceCollection();
services.AddScoped<App>();
services.AddFluxor(o => o.ScanAssemblies(typeof(Program).Assembly));

IServiceProvider servicesProvider = services.BuildServiceProvider();

var app = servicesProvider.GetRequiredService<App>();
app.Run();