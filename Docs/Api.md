# Miles Car Rental API

- [Miles Car Rental API](#miles-car-rental-api)
  - [Get Available Cars](#get-available-cars)
    - [Get Available Cars Request](#get-available-cars-request)
    - [Get Available Cars Response](#get-available-cars-response)
  - [Get Available Locations](#get-available-locations)
    - [Get Available Locations Request](#get-available-locations-request)
    - [Get Available Location Response](#get-available-locations-response)
    <!--  -->

## Get Available Cars

### Get Available Cars Request

```js
GET /cars/{{location}}
```

### Get Available Cars Response

```js
200 Ok
```

```json
[
  {
    "id": "00000000-0000-0000-0000-000000000000",
    "estado": "Alquilado",
    "bodega": 0,
    "type": ["Hibrid", "Offroad", "4x4", "SUV"],
    "startDateTime": "2024-02-24T08:00:00",
    "endDateTime": "2024-02-24T11:00:00",
    "lastModifiedDateTime": "2024-02-24T12:00:00"
  }
]
```

## Get Available Locations

### Get Available Locations Request

```js
GET /locations/{{location}}
```

### Get Available Locations Response

```js
200 Ok
```

```json
[
  {
    "id": "00000000-0000-0000-0000-000000000000",
    "capacidad": "100",
    "ubicacion": "12345678",
    "disponibilidad": 0,
    "startDateTime": "2024-02-24T08:00:00",
    "endDateTime": "2024-02-24T11:00:00",
    "lastModifiedDateTime": "2024-02-24T12:00:00"
  }
]
```
