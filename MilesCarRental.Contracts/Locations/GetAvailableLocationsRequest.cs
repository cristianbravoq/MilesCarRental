namespace MilesCarRental.Contracts.Locations;

public record GetAvailableLocationsRequest
{
    public string? location { get; init; }
}