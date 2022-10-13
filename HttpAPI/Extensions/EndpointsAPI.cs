using Shared.Domain.Bus.Query;
using Signaturit.Lawsuit.Application;
using Signaturit.Lawsuit.Application.EvaluateLawsuitWinner;
using Signaturit.Lawsuit.Application.EvaluateSignatureToWin;

namespace HttpAPI.Extensions
{
    public class EndpointsAPIMiddleware
    {
        private readonly RequestDelegate _next;

        public EndpointsAPIMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {

            return _next(context);
        }
    }

    public static class EndpointsAPIMiddlewareExtensions
    {
        public static IApplicationBuilder UseEndpointsAPIMiddleware(this IApplicationBuilder builder, WebApplication app)
        {
            app.MapGet("/evaluate-lawsuite-winner", (string plaintiffSignature, string defendantSignature, QueryBus bus) =>
            {
                return bus.Ask<EvaluateLawsuitWinnerResponse>(new EvaluateLawsuitWinnerQuery(plaintiffSignature, defendantSignature));
            });

            app.MapGet("/evaluate-signature-to-win", (string plaintiffSignature, string defendantSignature, QueryBus bus) =>
            {
                return bus.Ask<EvaluateSignatureToWinResponse>(new EvaluateSignatureToWinQuery(plaintiffSignature, defendantSignature));
            });

            return builder.UseMiddleware<EndpointsAPIMiddleware>();
        }
    }

}
