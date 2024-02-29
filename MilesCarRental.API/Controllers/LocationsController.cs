using MediatR;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Core.Modules.Locations.Create;
using MilesCarRental.Core.Modules.Locations.GetAll;
using MilesCarRental.Core.Modules.Locations.Update;
using MilesCarRental.Core.Modules.Locations.Delete;
using MilesCarRental.Core.Modules.Locations.GetAvailablesByName;
using MilesCarRental.Core.Modules.Locations.GetAllAvailables;

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

    [HttpGet("availables")]
    public async Task<IActionResult> GetAllAvailablesLocations()
    {
        var query = new GetAllAvailablesLocationsQuery();
        var locationsResult = await _mediator.Send(query);

        return locationsResult.Match(
            locations => Ok(locations),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllLocationsQuery();
        var locationsResult = await _mediator.Send(query);

        return locationsResult.Match(
            locations => Ok(locations),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLocationCommand command)
    {
        if (command.Id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("Location.UpdateInvalid", "The request Id does not match with the url Id.")
            };
            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            locationId => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteLocationResult = await _mediator.Send(new DeleteLocationCommand(id));

        return deleteLocationResult.Match(
            locationId => NoContent(),
            errors => Problem(errors)
        );
    }
}