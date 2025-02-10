using OptimalRoute.API.Models;

namespace OptimalRoute.API.Interfaces
{
    public interface IRouteService
    {
        RouteResponse CalculateOptimalRoute(RouteRequest request);
    }
}
