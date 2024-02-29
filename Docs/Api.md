# Miles Vehicle Rental API

- [Miles Vehicle Rental API](#miles-vehicles-rental-api)
  - [Vehicles](#vehicles)
    - [Create Vehicle](#create-vehicle)
      - [Create Vehicle Request](#create-vehicle-request)
      - [Create Vehicle Response](#create-vehicle-response)
    - [Get Available Vehicles](#get-available-vehicles)
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
POST /vehicles/create
```

```json
{
    "brand": "Toyota",
    "model": "2020",
    "state": "Available",
    "type": "4x4",
    "startDateTime": "2024-02-08T08:00:00",
}
```

### Create Vehicle Response

```js
201 Created
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "brand": "BMW",
    "model": "2020",
    "state": "Available",
    "type": "4x4",
    "startDateTime": "2024-02-08T08:00:00",
    "lastModifiedDateTime": "2024-02-06T12:00:00",
}
```

## Get Available Vehicles

### Get Available Vehicles Request

```js
POST /vehicles/available
```

```json
  {
    "DeliveryPlace": "Aeropuerto Miami",
  }
```

### Get Available Vehicles Response

```js
200 Ok
```

```json
[
  {
    "id": "00000000-0000-0000-0000-000000000000",
    "brand": "",
    "model": "",
    "type": "SUV",
  }
]
```

# Locations

## Create Location

### Create Location Request

```js
POST /location/available
```

```json
  {
    "capacity" : 20,
    "available" : true,
    "name" : "Aeropuerto Miami",
    "startDateTime": "2024-02-24T08:00:00"
  }
```

### Create Location Response

```js
200 Ok
```

```json
[
  {
    "id": "00000000-0000-0000-0000-000000000000",
    "capacity" : 20,
    "available" : true,
    "name" : "Aeropuerto Miami",
    "startDateTime": "2024-02-24T08:00:00",
    "lastModifiedDateTime": "2024-02-24T12:00:00"
  }
]
```

## Get Available Locations

### Get Available Locations Request

```js
POST /location/available
```

```json
  {
    "location": "Aeropuerto Mi",
  }
```

### Get Available Locations Response

```js
200 Ok
```

```json
[
  {
    "id": "00000000-0000-0000-0000-000000000000",
    "name" : "Aeropuerto Miami",
  },
  {
    "id": "00000000-0000-0000-0000-000000000001",
    "name" : "Aeropuerto Minnesota",
  }
]
```