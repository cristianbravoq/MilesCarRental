using ErrorOr;
using MediatR;
using MilesCarRental.Domain.DomainErrors;
using MilesCarRental.Domain.Entities.Locations;
using MilesCarRental.Domain.Primitives;
using MilesCarRental.Domain.ValueObjects;
using NetTopologySuite.Geometries;

namespace MilesCarRental.Core.Modules.Locations.Create;

public sealed class CreateLocationCommandHandler :
    IRequestHandler<CreateLocationCommand, ErrorOr<Guid>>
{
    private readonly ILocationRepository _locationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLocationCommandHandler(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
    {
        _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Guid>> Handle(CreateLocationCommand command, CancellationToken cancellationToken)
    {
        try
        {
            if (Address.Create(command.Country, command.Line1, command.Line2, command.City,
                    command.State, command.ZipCode) is not Address address)
                return ErrorsLocation.AddressWithBadFormat;


            var location = new Domain.Entities.Locations.Location(
                new LocationId(Guid.NewGuid()),
                command.Capacity,
                command.Available,
                command.Name,
                address,
                command.Latitude,
                command.Longitude,
                new Point(command.Longitude, command.Latitude) { SRID = 4326 }
                );

            _locationRepository.Add(location);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return location.Id.value;
        }
        catch (Exception ex)
        {
            return Error.Failure("Create location failed: " + ex.Message);
        }
    }
}