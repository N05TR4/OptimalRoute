

using OptimalRoute.API.Models;
using OptimalRoute.API.Services;

namespace OptimalRoute.API.Test.ServiceTest
{
    public class RouteServiceTests
    {
        private readonly RouteService _routeService;

        public RouteServiceTests()
        {
            _routeService = new RouteService();
        }

        [Fact]
        public void CalculateOptimalRoute_ShouldReturnCorrectRoute()
        {
            //Arange
            var request = new RouteRequest
            {
                Cities = new List<string> { "A", "B", "C", "D" },
                Roads = new List<Road>
                {
                    new Road { From = "A", To = "B", Time = 10 },
                    new Road { From = "B", To = "C", Time = 15 },
                    new Road { From = "A", To = "C", Time = 30 },
                    new Road { From = "C", To = "D", Time = 5 },
                    new Road { From = "B", To = "D", Time = 25 }
                },
                Origin = "A",
                Destination = "D"
            };

            //Act
            var result = _routeService.CalculateOptimalRoute(request);

            //Assert
            Assert.Equal(new List<string> { "A", "B", "C", "D" }, result.Route);
            Assert.Equal(30, result.TotalTime);


        }


        [Fact]
        public void CalculateOptimalRoute_ShouldHandleNoPathScenery()
        {
            // Arrange
            var request = new RouteRequest
            {
                Cities = new List<string> { "A", "B", "C" },
                Roads = new List<Road>
                {
                    new Road { From = "A", To = "B", Time = 10 }
                },
                Origin = "A",
                Destination = "C"
            };

            // Act
            var result = _routeService.CalculateOptimalRoute(request);

            // Assert
            Assert.Empty(result.Route); // Debe estar vacío si no hay camino a "C"
            Assert.Equal(int.MaxValue, result.TotalTime); // Tiempo máximo si no hay ruta
        }

    }
}
