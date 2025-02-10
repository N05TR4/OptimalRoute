using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptimalRoute.API.Interfaces;
using OptimalRoute.API.Models;

namespace OptimalRoute.API.Controllers
{
    [Route("api/optimal-route")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
            
        }

        [HttpPost("GetOptimalRoute")]
        public ActionResult<RouteResponse> GetOptimalRoute([FromBody] RouteRequest request)
        {
            var result = _routeService.CalculateOptimalRoute(request);
            return Ok(result);
        }


    }
}
