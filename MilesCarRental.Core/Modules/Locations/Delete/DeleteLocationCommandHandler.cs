using ErrorOr;
using MediatR;
using MilesCarRental.Domain.DomainErrors;
using MilesCarRental.Domain.Entities.Locations;
using MilesCarRental.Domain.Primitives;

namespace MilesCarRental.Core.Modules.Locations.Delete;

internal sealed class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, ErrorOr<Unit>>
{
    private readonly ILocationRepository _locationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLocationCommandHandler(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
    {
        _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteLocationCommand command, CancellationToken cancellationToken)
    {
        if(await  _locationRepository.GetByIdAsync(new LocationId(command.Id)) is not Location location)
            return ErrorsLocation.IdProvidedNotFound; 

        _locationRepository.Delete(location);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}