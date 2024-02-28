using MediatR;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Contracts.Cars;
using MilesCarRental.Core.Modules.Vehicles.Create;

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
    public IActionResult GetAvailableCars(GetAvailableCarRequest request)
    {
        
        return Ok(request);
    }
}