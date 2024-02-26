namespace MilesCarRental.Contracts.Cars;

public record CreateCarRequest
{
    public string? BrandName { get; init; }
    public string? Model { get; init; }
    public string? State { get; init; }
    public string? Type { get; init; }
    public DateTime StartDateTime { get; init; }
}