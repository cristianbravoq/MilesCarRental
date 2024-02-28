using MediatR;
using Microsoft.AspNetCore.Mvc;

using MilesCarRental.Contracts.Locations;
using MilesCarRental.Core.Modules.Vehicles.Create;
using MilesCarRental.Core.Modules.Locations.Create;
using MilesCarRental.Core.Modules.Locations.GetAvailablesByName;

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
            location => Ok(),
            errors => Problem(errors)
        );
    }

    [HttpPost("availables")]
    public async Task<IActionResult> GetAvailablesByNameLocations([FromBody] GetAvailablesLocationsByNameQuery query)
    {
        var availableLocationsResult = await _mediator.Send(query);

        return availableLocationsResult.Match(
            locations => Ok(locations),
            errors => Problem(errors)
        );
    }
}
