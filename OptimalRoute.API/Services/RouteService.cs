using OptimalRoute.API.Interfaces;
using OptimalRoute.API.Models;

namespace OptimalRoute.API.Services
{
    public class RouteService : IRouteService
    {
        public RouteResponse CalculateOptimalRoute(RouteRequest request)
        {
            var graph = new Dictionary<string, List<(string, int)>>();

            foreach (var road in request.Roads)
            {
                if (!graph.ContainsKey(road.From)) graph[road.From] = new List<(string, int)>();
                if (!graph.ContainsKey(road.To)) graph[road.To] = new List<(string, int)>();

                graph[road.From].Add((road.To, road.Time));
                graph[road.To].Add((road.From, road.Time));

            }

            var shortesPaths = new Dictionary<string, int>();
            var previousNodes = new Dictionary<string, string>();
            var unvisted = new HashSet<string>(request.Cities);

            foreach(var city in request.Cities)
                shortesPaths[city] = int.MaxValue;

            shortesPaths[request.Origin] = 0;

            while(unvisted.Count > 0)
            {
                var currentCity = unvisted.OrderBy(city => shortesPaths[city]).First();
                unvisted.Remove(currentCity);

                if(currentCity == request.Destination) break;
          
                if (shortesPaths[currentCity] == int.MaxValue)
                {
                    return new RouteResponse
                    {
                        Route = new List<string>(),
                        TotalTime = int.MaxValue
                    };
                }

                foreach(var (neighbor, travelTime) in graph[currentCity])
                {
                    int newDistance = shortesPaths[currentCity] + travelTime;

                    if(newDistance < shortesPaths[neighbor])
                    {
                        shortesPaths[neighbor] = newDistance;
                        previousNodes[neighbor] = currentCity;
                    }
                }
            }

            // Si el destino nunca fue alcanzado, no hay ruta válida
            if (!previousNodes.ContainsKey(request.Destination))
            {
                return new RouteResponse
                {
                    Route = new List<string>(),
                    TotalTime = int.MaxValue
                };
            }

            // Construcción de la ruta óptima
            var route = new List<string>();
            var current = request.Destination;

            while (previousNodes.ContainsKey(current))
            {
                route.Insert(0, current);
                current = previousNodes[current];
            }
            route.Insert(0, request.Origin);

            return new RouteResponse
            {
                Route = route,
                TotalTime = shortesPaths[request.Destination]
            };


        }
    }
}
