# Miles Car Rental API

- [Miles Car Rental API](#miles-car-rental-api)
  - [Cars](#cars)
    - [Create Car](#create-car)
      - [Create Car Request](#create-car-request)
      - [Create Car Response](#create-car-response)
    - [Get Available Cars](#get-available-cars)
      - [Get Available Cars Request](#get-available-cars-request)
      - [Get Available Cars Response](#get-available-cars-response)
  - [Locations](#locations)
    - [Create Location](#create-location)
      - [Create Location Request](#create-location-request)
      - [Create Location Response](#create-location-response)
    - [Get Available Locations](#get-available-locations)
      - [Get Available Locations Request](#get-available-locations-request)
      - [Get Available Location Response](#get-available-locations-response)
    <!--  -->

# Cars

## Create car

### Create Car Request

```js
POST /car
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

### Create Car Response

```js
201 Created
```

```yml
Location: {{host}}/Breakfasts/{{id}}
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

## Get Available Cars

### Get Available Cars Request

```js
POST /available
```

```json
  {
    "DeliveryPlace": "Aeropuerto Miami",
  }
```

### Get Available Cars Response

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
POST /available
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
POST /available
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