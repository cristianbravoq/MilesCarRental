# Miles Car Rental

## Comandos de creación

1. Crear un proyecto de biblioteca de clases:
    ```bash
    dotnet new classlib -o MilesCarRental.Infrastructure
    dotnet new classlib -o MilesCarRental.Core
    dotnet new classlib -o MilesCarRental.Domain
    ```

2. Crear un proyecto de API web utilizando .NET 6.0:
    ```bash
    dotnet new webapi -f net6.0 -o MilesCarRental.API
    ```

3. Crear un proyecto de pruebas unitarias con xUnit utilizando .NET 6.0:
    ```bash
    dotnet new xunit -f net6.0 -o MilesCarRental.UnitTests
    ```

4. Agregar proyectos al archivo de solución:
    ```bash
    dotnet sln add (ls -r **/*.csproj)
    ```

## Comando para referenciar entre proyectos

Referenciar el proyecto de infraestructura desde el proyecto de API:
  ```js
    dotnet add .\MilesCarRental.API\ reference .\MilesCarRental.Infraestructure\
  ```

##API

- [Miles Vehicle Rental API](#miles-vehicles-rental-api)
  - [Vehicles](#vehicles)
    - [Create Vehicle](#create-vehicle)
      - [Create Vehicle Request](#create-vehicle-request)
      - [Create Vehicle Response](#create-vehicle-response)
    - [Get Available Vehicles By Ubication](#get-available-vehicles-by-ubitacation)
      - [Get Available Vehicles Request](#get-available-vehicles-request)
      - [Get Available Vehicles Response](#get-available-vehicles-response)
  - [Locations](#locations)
    - [Create Location](#create-location)
      - [Create Location Request](#create-location-request)
      - [Create Location Response](#create-location-response)
    - [Get Available Locations](#get-available-locations)
      - [Get Available Locations Request](#get-available-locations-request)
      - [Get Available Location Response](#get-available-locations-response)
      <!--  -->

# Vehicles

## Create Vehicle

### Create Vehicle Request

```js
POST /vehicles/create;
```

```json
{
  "Brand": "Bwm",
  "Model": "Camry",
  "Type": 3,
  "State": 1,
  "LocationId": "207F33A7-1CB1-4A23-A0EB-CBC3644D7ABF"
}
```

### Create Vehicle Response

```js
201 Created
```

## Get Available Vehicles By Ubication

### Get Available Vehicles Request

```js
POST /vehicles/availables;
```

```json
{
  "locationSelectedId": "3EF15446-BC96-402E-B655-321FFA19561D",
  "latitudeUser": 6.2476,
  "longitudeUser": 75.5658
}
```

### Get Available Vehicles Response

```js
200 Ok
```

```json
[
  {
    "id": "2ca1257f-79dd-40a1-baee-0648363eca2d",
    "brand": "Mercedez",
    "model": "Camry",
    "type": 3,
    "state": 1,
    "locationAddress": {
      "country": "COL",
      "line1": "123 Main St",
      "line2": "Apt 2",
      "city": "Medellin",
      "state": "MED",
      "zipCode": "10001"
    },
    "latitude": 6.2476,
    "longitude": 75.5658
  }
]
```

# Locations

## Create Location

### Create Location Request

```js
POST /locations/create;
```

```json
{
  "Capacity": 25,
  "Available": false,
  "Name": "Location Rionegro",
  "Country": "USA",
  "Line1": "123 Main St",
  "Line2": "Apt 2",
  "City": "Medellin",
  "State": "MED",
  "ZipCode": "10001",
  "Latitude": 6.2876,
  "Longitude": 75.698
}
```

### Create Location Response

```js
200 Ok
```

## Get Available Locations By Name

### Get Available Locations Request

```js
POST /locations/availables;
```

```json
{
  "name": "oca"
}
```

### Get Available Locations Response

```js
200 Ok
```

```json
[
  {
    "id": "bf7b7387-0974-48b4-99b3-2cd395acd812",
    "capacity": 25,
    "available": true,
    "name": "Location Rionegro",
    "address": {
      "country": "USA",
      "line1": "123 Main St",
      "line2": "Apt 2",
      "city": "Medellin",
      "state": "MED",
      "zipCode": "10001"
    },
    "latitude": 6.2876,
    "longitude": 75.698
  }
]
```
