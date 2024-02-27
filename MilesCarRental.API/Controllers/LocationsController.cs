using Microsoft.AspNetCore.Mvc;

using MilesCarRental.Contracts.Locations;

namespace MilesCarRental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {

        [HttpPost("create")]
        public IActionResult CreateLocation(CreateLocationRequest request)
        {
            return Ok(request);
        }

        [HttpPost("availables")]
        public IActionResult GetAvailableLocations(GetAvailableLocationsRequest request)
        {
            return Ok(request);
        }
    }
}
