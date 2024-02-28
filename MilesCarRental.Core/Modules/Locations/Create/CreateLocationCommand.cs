using ErrorOr;
using MediatR;

namespace MilesCarRental.Core.Modules.Locations.Create;

public record CreateLocationCommand(
        int Capacity,
        bool Available,
        string Name,
        string Country,
        string Line1,
        string Line2,
        string City,
        string State,
        string ZipCode,
        double Latitude,
        double Longitude
) : IRequest<ErrorOr<Unit>>;