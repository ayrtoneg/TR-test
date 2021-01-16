using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OLC.Cases.Api.Application.Commands;
using OLC.Cases.Api.Data;
using OLC.Cases.Api.Data.Repositories;
using OLC.Cases.Api.Models;
using OLC.Core.Mediator;

namespace OLC.Cases.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<NewCaseCommand, ValidationResult>, CaseCommandHandler>();

            services.AddScoped<ICaseRepository, CaseRepository>();

            services.AddScoped<LegalCaseContext>();
        }
    }
}
