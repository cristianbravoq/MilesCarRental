using ErrorOr;
using MediatR;
using MilesCarRental.Domain.DomainErrors;
using MilesCarRental.Domain.Entities.Locations;
using MilesCarRental.Domain.Entities.Vechicles;
using MilesCarRental.Domain.Primitives;

namespace MilesCarRental.Core.Modules.Vehicles.Create;

internal sealed class CreateVehiclesCommandHandler :
    IRequestHandler<CreateVehiclesCommand, ErrorOr<Unit>>
{
    private readonly IVehicleRepository _vehiclesRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehiclesCommandHandler(IVehicleRepository vehiclesRepository, IUnitOfWork unitOfWork)
    {
        _vehiclesRepository = vehiclesRepository ?? throw new ArgumentNullException(nameof(vehiclesRepository));
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateVehiclesCommand command, CancellationToken cancellationToken)
    {
        if(command.Brand.Length < 3 || command.Brand.Length > 15)
            return ErrorsVechicles.InvalidBrand;

        if(command.Model.Length < 3 || command.Brand.Length > 5)
            return ErrorsVechicles.InvalidModel;        

        var vehicles = new Vehicle(
            new VehicleId(Guid.NewGuid()),
            command.Brand,
            command.Model,
            command.Type,
            command.State,
            new LocationId(command.LocationId)
        );

        _vehiclesRepository.Add(vehicles);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}