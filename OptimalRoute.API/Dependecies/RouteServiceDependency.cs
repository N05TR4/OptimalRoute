using Microsoft.Extensions.DependencyInjection;
using OptimalRoute.API.Interfaces;
using OptimalRoute.API.Services;

namespace OptimalRoute.API.Dependecies
{
    public static class RouteServiceDependency
    {
        public static void AddRouteServiceDependency(this IServiceCollection service)
        {
            service.AddScoped<IRouteService, RouteService>();
        }
            
    }
}
