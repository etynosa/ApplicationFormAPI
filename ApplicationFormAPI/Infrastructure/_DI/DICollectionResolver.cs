
using ApplicationFormAPI.Services.Implementations;
using ApplicationFormAPI.Services.Interfaces;

namespace ApplicationFormAPI.Infrastructure._DI
{
    public static class DICollectionResolver
    {
        public static void RegisterAllDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureCosmos(configuration);
            services.AddScoped<IApplicationFormService, ApplicationFormService>();
            services.AddScoped<ISubmittedApplicationService, SubmittedApplicationService>();
        }
    }
}
