using FluentValidation;
using Shared;
using Shared.Helpers;
using Signaturit.Contract.Application.Create;
using Signaturit.Lawsuit.Application.EvaluateLawsuitWinner;
using Signaturit.Lawsuit.Application.EvaluateSignatureToWin;
using Signaturit.Roles.Application.FindByCriteria;
using System.Reflection;

namespace HttpAPI.Extensions.DependencyInjection
{
    public static class Application
    {
        internal static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddValidatorsFromAssembly(Assembly.Load(Assemblies.Signaturit));
            services.AddQueryServices(Assembly.Load(Assemblies.Signaturit));

            services.AddScoped<EvaluateLawsuitWinnerService, EvaluateLawsuitWinnerService>();
            services.AddScoped<EvaluateSignatureToWinService, EvaluateSignatureToWinService>();
            services.AddScoped<CreateContractService, CreateContractService>();
            services.AddScoped<FindRolesService, FindRolesService>();

            return services;
        }
    }
}
