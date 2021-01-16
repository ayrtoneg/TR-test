using Microsoft.Extensions.DependencyInjection;
using OLC.Cases.Api.Data;
using OLC.Core.Mediator;

namespace OLC.Cases.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<LegalCaseContext>();
        }
    }
}
