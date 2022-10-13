using ConsoleApp.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Domain.Bus.Query;
using Shared.Infrastructure.Bus.Query;
using Signaturit.Contract.Application.Create;
using Signaturit.Lawsuit.Application.EvaluateLawsuitWinner;
using Signaturit.Roles.Application.FindByCriteria;
using System.Reflection;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var hostBuilder = CreateHostBuilder(args);

        await hostBuilder.RunConsoleAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostingContext, services) =>
            {
                services.AddApplication();
                services.AddInfrastructure();

                services.AddSingleton<IHostedService, ConsoleApp.ConsoleApp>();
            });
}