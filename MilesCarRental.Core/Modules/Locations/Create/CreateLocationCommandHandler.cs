using ErrorOr;
using MediatR;
using MilesCarRental.Domain.DomainErrors;
using MilesCarRental.Domain.Entities.Locations;
using MilesCarRental.Domain.Primitives;
using MilesCarRental.Domain.ValueObjects;

namespace MilesCarRental.Core.Modules.Locations.Create;

internal sealed class CreateLocationCommandHandler :
    IRequestHandler<CreateLocationCommand, ErrorOr<Unit>>
{
    private readonly ILocationRepository _locationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLocationCommandHandler(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
    {
        _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateLocationCommand command, CancellationToken cancellationToken)
    {
        try
        {
            ////
            //Here you enter the validations that could trigger errors
            if (Address.Create(command.Country, command.Line1, command.Line2, command.City,
                    command.State, command.ZipCode) is not Address address)
            {
                return ErrorsLocation.AddressWithBadFormat;
            }

            var location = new Location(
                new LocationId(Guid.NewGuid()),
                command.Capacity,
                command.Available,
                command.Name,
                address,
                command.Latitude,
                command.Longitude);

            _locationRepository.Add(location);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (Exception ex)
        {
            return Error.Failure("Create location failed: " + ex.Message);
        }
    }
}