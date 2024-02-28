using ErrorOr;
using MediatR;
using MilesCarRental.Domain.Entities.Locations;
using MilesCarRental.Domain.Primitives;
using MilesCarRental.Domain.ValueObjects;
using NetTopologySuite.Geometries;

namespace MilesCarRental.Core.Modules.Locations.Update;

internal sealed class UpdateLocationCommandHandler :
    IRequestHandler<UpdateLocationCommand, ErrorOr<Unit>>
{
    private readonly ILocationRepository _locationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLocationCommandHandler(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
    {
        _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateLocationCommand command, CancellationToken cancellationToken)
    {
        
        if(!await _locationRepository.ExistsAsync(new LocationId(command.Id)))
        {
            return Error.NotFound("Location.NotFound", "The location with the provide Id was not found.");
        }

        if (Address.Create(command.Country, command.Line1, command.Line2, command.City,
                    command.State, command.ZipCode) is not Address address)
        {
            return Error.Validation("Location.Address", "Address is not valid.");
        }

        var location = new Domain.Entities.Locations.Location(
            new LocationId(command.Id),
            command.Capacity,
            command.Available,
            command.Name,
            address,
            command.Latitude,
            command.Longitude,
            new Point(command.Longitude, command.Latitude)
        );

        _locationRepository.Update(location);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}