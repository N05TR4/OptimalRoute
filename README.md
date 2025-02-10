# OptimalRoute

## Descripción
Esta API calcula la ruta más corta entre dos ciudades basándose en conexiones de carreteras.

## Tecnologías Usadas
- .NET 8
- ASP.NET Core
- Swagger

## Cómo Ejecutar el Proyecto
1. Clonar el repositorio:
   git clone https://github.com/N05TR4/OptimalRoute.git
   cd OptimalRouteAPI

2. Ejecutar la API:
   dotnet run

3. Accede a Swagger:
    http://localhost:5000/swagger

# Ejemplo de uso

## Solicitud

{
  "cities": ["A", "B", "C", "D"],
  "roads": [
    {"from": "A", "to": "B", "time": 10},
    {"from": "B", "to": "C", "time": 15},
    {"from": "A", "to": "C", "time": 30},
    {"from": "C", "to": "D", "time": 5},
    {"from": "B", "to": "D", "time": 25}
  ],
  "origin": "A",
  "destination": "D"
}


## Respuesta

{
  "route": ["A", "B", "C", "D"],
  "totalTime": 30
}
