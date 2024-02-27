using MediatR;
using Microsoft.AspNetCore.Mvc;

using MilesCarRental.Contracts.Locations;
using MilesCarRental.Core.Modules.Cars.Create;
using MilesCarRental.Core.Modules.Locations.Create;

namespace MilesCarRental.API.Controllers;

[Route("[controller]")]
public class LocationsController : ApiController
{
    private readonly ISender _mediator;

    public LocationsController(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));        
    }


    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateLocationCommand command)
    {
        var createLocationResult = await _mediator.Send(command);
        return createLocationResult.Match(
            car => Ok(),
            errors => Problem(errors)
        );
    }

    [HttpPost("availables")]
    public IActionResult GetAvailableLocations(GetAvailableLocationsRequest request)
    {
        return Ok(request);
    }
}
