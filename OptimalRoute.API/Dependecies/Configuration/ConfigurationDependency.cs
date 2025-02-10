

namespace OptimalRoute.API.Dependecies.Configuration
{
    public static class ConfigurationDependency
    {
        public static void AddConfigurationDependencies(this IServiceCollection services)
        {
            services.AddRouteServiceDependency();
        }
    }
}
