using ErrorOr;
using MediatR;
using MilesCarRental.Core.Modules.Vehicles.Common;
using MilesCarRental.Domain.Entities.Vechicles;
using MilesCarRental.Domain.Enumerations;

namespace MilesCarRental.Core.Modules.Vehicles.GetAll;

internal sealed class GetAllVehiclesQueryHanlder : IRequestHandler<GetAllVehiclesQuery, ErrorOr<IReadOnlyList<VehiclesResponse>>>
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetAllVehiclesQueryHanlder(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
    }
    public async Task<ErrorOr<IReadOnlyList<VehiclesResponse>>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Domain.Entities.Vechicles.Vehicle> vehicles = await _vehicleRepository.GetAll();

        return vehicles.Select(
            vehicle => new VehiclesResponse(
                vehicle.Id!.value,
                vehicle.Brand!,
                vehicle.Model!,
                (ClasificationVehicleType)vehicle.Type,
                (StateVehicleType)vehicle.State,
                vehicle.Location.Address,
                vehicle.Location.Latitude,
                vehicle.Location.Longitude
            )
        ).ToList();
    }
}