using MilesCarRental.Domain.ValueObjects;

namespace MilesCarRental.Core.Modules.Locations.Common;

public record LocationResponse(
    Guid Id,
    int Capacity,
    bool Available,
    string Name,
    Address Address,
    double Latitude,
    double Longitude
);