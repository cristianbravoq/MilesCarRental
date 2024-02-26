namespace MilesCarRental.Contracts.Cars;

public record GetAvailableCarRequest
{
    public string? DeliveryPlace { get; init; }
}