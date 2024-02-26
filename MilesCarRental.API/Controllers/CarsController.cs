using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Contracts.Cars;
using MilesCarRental.Core.Entities;
using MilesCarRental.Core.Services.Contracts;

namespace MilesCarRental.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;        
    }

    [HttpPost("create")]
    public IActionResult CreateCar(CreateCarRequest request)
    {
        
        return Ok(request);
    }

    [HttpPost("availables")]
    public IActionResult GetAvailableCars(GetAvailableCarRequest request)
    {
        
        return Ok(request);
    }

}
