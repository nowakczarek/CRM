using CRM.Infrastructure.Data;
using CRM.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace CRM.Api.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<CrmDbContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
