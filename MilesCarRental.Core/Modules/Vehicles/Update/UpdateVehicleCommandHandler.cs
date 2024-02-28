using ErrorOr;
using MediatR;
using MilesCarRental.Domain.Entities.Vechicles;
using MilesCarRental.Domain.Primitives;

namespace MilesCarRental.Core.Modules.Vehicles.Update;

internal sealed class UpdateVehicleCommandHandler :
    IRequestHandler<UpdateVehicleCommand, ErrorOr<Unit>>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    {
        _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateVehicleCommand command, CancellationToken cancellationToken)
    {
        ////
        //Here you enter the validations that could trigger errors.
        if (await _vehicleRepository.ExistsAsync(new VehicleId(command.Id)) is not Domain.Entities.Vechicles.Vehicle item)
        {
            return Error.NotFound("Vehicle.NotFound", "The vehicle with the provide Id was not found.");
        }

        var vehicle = new Vehicle(
            new VehicleId(command.Id),
            command.Brand,
            command.Model,
            command.Type,
            command.State
        );

        _vehicleRepository.Update(vehicle);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}