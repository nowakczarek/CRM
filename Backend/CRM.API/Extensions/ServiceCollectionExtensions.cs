using CRM.Application.Services.Implementations;
using CRM.Application.Services.Interfaces;
using CRM.Core.Interfaces.Repositories;
using CRM.Infrastructure.Repositories;

namespace CRM.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ILeadService, LeadService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IContactRepository, ContactRepository>();

            return services;
        }
    }
}
