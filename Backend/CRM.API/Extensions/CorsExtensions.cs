namespace CRM.Api.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("FrontendPolicy", policy =>
                {
                    // to change
                    policy.WithOrigins("front-end-server")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            return services;
        }
    }
}
