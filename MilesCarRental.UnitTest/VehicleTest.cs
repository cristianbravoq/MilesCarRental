using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using MediatR;
using Microsoft.AspNetCore.Mvc;

using MilesCarRental.API.Controllers;
using MilesCarRental.Core.Modules.Locations.Common;
using MilesCarRental.Core.Modules.Locations.GetAvailablesByName;
using MilesCarRental.Core.Modules.Vehicles.Common;
using MilesCarRental.Core.Modules.Vehicles.Create;
using MilesCarRental.Core.Modules.Vehicles.GetById;
using MilesCarRental.Core.Modules.Vehicles.Update;
using MilesCarRental.Domain.DomainErrors;
using MilesCarRental.Domain.Entities.Locations;
using MilesCarRental.Domain.Entities.Vechicles;
using MilesCarRental.Domain.Enumerations;
using MilesCarRental.Domain.Primitives;
using Moq;

namespace MilesCarRental.UnitTest;

public class VehicleTest
{
    private readonly Mock<IVehicleRepository> _vehicleRepository;
    private readonly Mock<IUnitOfWork> _unitOfWork;

    public VehicleTest()
    {
        _vehicleRepository = new();
        _unitOfWork = new();
    }

    [Fact]
    public async Task Create_ValidCommand_Returns_OkResult()
    {
        // Arrange
        var mediatorMock = new Mock<ISender>();
        var controller = new VehiclesController(mediatorMock.Object);
        var command = new CreateVehiclesCommand("","",Domain.Enumerations.ClasificationVehicleType.Convertible,StateVehicleType.Available, Guid.NewGuid());

        // Act
        var result = await controller.Create(command);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task GetAvailableVehiclesByUbication_ValidQuery_Returns_OkResult()
    {
        // Arrange
        var mediatorMock = new Mock<ISender>();
        var controller = new VehiclesController(mediatorMock.Object);
        var query = new GetAvailableVehiclesByUbicationQuery(Guid.NewGuid(), 20.3,40.3);

        // Act
        var result = await controller.GetAvailableVehiclesByUbication(query);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GetAll_Returns_OkResult()
    {
        // Arrange
        var mediatorMock = new Mock<ISender>();
        var controller = new VehiclesController(mediatorMock.Object);

        // Act
        var result = await controller.GetAll();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GetVehicleById_ValidId_Returns_OkResult()
    {
        // Arrange
        var mediatorMock = new Mock<ISender>();
        var controller = new VehiclesController(mediatorMock.Object);
        var id = Guid.NewGuid();

        // Act
        var result = await controller.GetVehicleById(id);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Brand_Is_Valid_When_Length_Is_Between_Min_And_Max()
    {
        // Arrange
        var validBrand = new string('a', Vehicle.MaxBrandLength); // Brand length equal to MaxBrandLength
        var vehicle = new Vehicle(
            new VehicleId(Guid.NewGuid()),
            validBrand,
            "Model",
            ClasificationVehicleType.Sedan,
            StateVehicleType.Available,
            new LocationId(Guid.NewGuid())
        );

        // Act & Assert
        Assert.Equal(validBrand, vehicle.Brand);
    }

    [Fact]
    public void Model_Is_Valid_When_Length_Is_Between_Min_And_Max()
    {
        // Arrange
        var validModel = new string('b', Vehicle.MaxModelLength); // Model length equal to MaxModelLength
        var vehicle = new Vehicle(
            new VehicleId(Guid.NewGuid()),
            "Brand",
            validModel,
            ClasificationVehicleType.Sedan,
            StateVehicleType.Available,
            new LocationId(Guid.NewGuid())
        );

        // Act & Assert
        Assert.Equal(validModel, vehicle.Model);
    }

}
