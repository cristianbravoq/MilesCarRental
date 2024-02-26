using Microsoft.AspNetCore.Mvc;

using MilesCarRental.Contracts.Locations;
using MilesCarRental.Core.Services.Contracts;

namespace MilesCarRental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

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
