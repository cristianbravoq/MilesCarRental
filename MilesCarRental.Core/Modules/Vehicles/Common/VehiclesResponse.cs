using MilesCarRental.Domain.Enumerations;
using MilesCarRental.Domain.ValueObjects;

namespace MilesCarRental.Core.Modules.Vehicles.Common;

public record VehiclesResponse(
    Guid Id,
    string Brand,
    string Model,
    ClasificationVehicleType Type,
    StateVehicleType State,
    Address LocationAddress,
    double Latitude,
    double Longitude
);