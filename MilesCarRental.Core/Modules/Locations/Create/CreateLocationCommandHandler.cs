using ErrorOr;
using MediatR;
using MilesCarRental.Domain.Entities.Locations;
using MilesCarRental.Domain.Primitives;

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

            var location = new Location(
                new LocationId(Guid.NewGuid()),
                command.Capacity,
                command.Available,
                command.Name
            );

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