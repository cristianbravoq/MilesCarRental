namespace MilesCarRental.Domain.Entities.Vechicles;

public record VehiclesAvailablesByLocationRequest(
    Guid locationSelectedId,
    double LatitudeUser,
    double LongitudeUser
);