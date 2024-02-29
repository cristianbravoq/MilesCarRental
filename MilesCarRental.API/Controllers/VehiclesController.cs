using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Core.Modules.Vehicles.Create;
using MilesCarRental.Core.Modules.Vehicles.Delete;
using MilesCarRental.Core.Modules.Vehicles.GetAll;
using MilesCarRental.Core.Modules.Vehicles.GetById;
using MilesCarRental.Core.Modules.Vehicles.Update;

namespace MilesCarRental.API.Controllers;

[Route("[controller]")]
public class VehiclesController : ApiController
{
    private readonly ISender _mediator;

    public VehiclesController(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }


    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateVehiclesCommand command)
    {
        var createVehicleResult = await _mediator.Send(command);

        return createVehicleResult.Match(
            vehicle => Ok(),
            errors => Problem(errors)
        );
    }

    [HttpPost("availables")]
    public async Task<IActionResult> GetAvailableVehiclesByUbication([FromBody] GetAvailableVehiclesByUbicationQuery query)
    {
        var vehiclesResult = await _mediator.Send(query);

        return vehiclesResult.Match(
            vehicles => Ok(vehicles),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllVehiclesQuery();
        var vehiclesResult = await _mediator.Send(query);

        return vehiclesResult.Match(
            vehicles => Ok(vehicles),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVehicleById(Guid id)
    {
        var query = new GetVehicleByIdQuery(id);
        var vehicleResult = await _mediator.Send(query);

        return vehicleResult.Match(
            vehicle => Ok(vehicle),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVehicleCommand command)
    {
        if (command.Id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("Vehicle.UpdateInvalid", "The request Id does not match with the url Id.")
            };
            return Problem(errors);
        }

        var updateVehicleResult = await _mediator.Send(command);

        return updateVehicleResult.Match(
            vehicleId => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteVehicleResult = await _mediator.Send(new DeleteVehiclesCommand(id));

        return deleteVehicleResult.Match(
            vehicleId => NoContent(),
            errors => Problem(errors)
        );
    }
}