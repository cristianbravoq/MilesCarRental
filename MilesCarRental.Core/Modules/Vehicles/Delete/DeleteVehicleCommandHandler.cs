using ErrorOr;
using MediatR;
using MilesCarRental.Domain.DomainErrors;
using MilesCarRental.Domain.Entities.Vechicles;
using MilesCarRental.Domain.Primitives;

namespace MilesCarRental.Core.Modules.Vehicles.Delete;

internal sealed class DeleteVehiclesCommandHandler : IRequestHandler<DeleteVehiclesCommand, ErrorOr<Unit>>
{
    private readonly IVehicleRepository _vehiclesRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehiclesCommandHandler(IVehicleRepository vehiclesRepository, IUnitOfWork unitOfWork)
    {
        _vehiclesRepository = vehiclesRepository ?? throw new ArgumentNullException(nameof(vehiclesRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteVehiclesCommand command, CancellationToken cancellationToken)
    {
        if (await _vehiclesRepository.GetByIdAsync(new VehicleId(command.Id)) is not Domain.Entities.Vechicles.Vehicle vehicle)
            return ErrorsVechicles.IdProvidedNotFoundException;

        _vehiclesRepository.Delete(vehicle);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}