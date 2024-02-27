using MediatR;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Contracts.Cars;
using MilesCarRental.Core.Modules.Cars.Create;

namespace MilesCarRental.API.Controllers;

[Route("[controller]")]
public class CarsController : ApiController
{
    private readonly ISender _mediator;

    public CarsController(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));        
    }


    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateCarCommand command)
    {
        var createCarResult = await _mediator.Send(command);
        return createCarResult.Match(
            car => Ok(),
            errors => Problem(errors)
        );
    }

    [HttpPost("availables")]
    public IActionResult GetAvailableCars(GetAvailableCarRequest request)
    {
        
        return Ok(request);
    }
}