using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared.Domain.Bus.Query;
using Signaturit.Lawsuit.Application;
using Signaturit.Lawsuit.Application.EvaluateLawsuitWinner;
using Signaturit.Lawsuit.Application.EvaluateSignatureToWin;

namespace ConsoleApp
{
    public class ConsoleApp : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public ConsoleApp(ILogger<ConsoleApp> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting Signaturit Console App");
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine("Please choose one of the following options:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Evaluate Lawsuit Winner");
                Console.WriteLine("2. Evaluate Signature To Win");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    choice = -1;
                }

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye...");
                        break;
                    case 1:
                    case 2:
                        Console.WriteLine("Enter Plaintiff Signature:");
                        string plaintiffContractSignature = Console.ReadLine();

                        Console.WriteLine("Enter Defendant Signature:");
                        string defendantContractSignature = Console.ReadLine();

                        using (var scope = _serviceScopeFactory.CreateScope())
                        {
                            QueryBus bus = scope.ServiceProvider.GetRequiredService<QueryBus> ();
                            dynamic response = null;

                            if (choice == 1)
                            {
                                response = await bus.Ask<EvaluateLawsuitWinnerResponse>(new EvaluateLawsuitWinnerQuery(plaintiffContractSignature, defendantContractSignature));
                            }
                            else
                            { 
                                response = await bus.Ask<EvaluateSignatureToWinResponse>(new EvaluateSignatureToWinQuery(plaintiffContractSignature, defendantContractSignature));
                            }
                            
                            Console.WriteLine (JsonConvert.SerializeObject(response, Formatting.Indented));
                        }
                    
                        
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
