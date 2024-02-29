using MediatR;

using Microsoft.AspNetCore.Mvc;

using MilesCarRental.API.Controllers;
using MilesCarRental.Core.Modules.Locations.Create;
using MilesCarRental.Domain.Entities.Locations;
using MilesCarRental.Domain.Primitives;
using MilesCarRental.Domain.ValueObjects;

using Moq;

using NetTopologySuite.Geometries;

namespace MilesCarRental.UnitTest;

public class LocationTests
{
    private readonly Mock<ILocationRepository> _locationRepository;
    private readonly Mock<IUnitOfWork> _unitOfWork;

    public LocationTests()
    {
        _locationRepository = new ();
        _unitOfWork = new();
    }

    [Fact]
    public async Task Create_ValidCommand_ReturnsOkResult()
    {
        // Arrange
        var mediatorMock = new Mock<ISender>();

        var controller = new LocationsController(mediatorMock.Object);
        var command = new CreateLocationCommand(
            20,true,
            "Name","",
            "Direccion 1", "Direcion 2",
            "Miami","Florida",
            "050402",
            40.3,410.2);

        // Act
        var result = await controller.Create(command);

        // Assert
        Assert.IsType<OkResult>(result);
        mediatorMock.Verify(m => m.Send(It.IsAny<CreateLocationCommand>(), default), Times.Once);
        mediatorMock.Verify(m => m.Send(command, default), Times.Once);
    }

    [Fact]
    public void Address_Create_Returns_Address_With_Correct_Values()
    {
        // Arrange
        var country = "Country";
        var line1 = "Line 1";
        var line2 = "Line 2";
        var city = "City";
        var state = "State";
        var zipCode = "ZipCode";

        // Act
        var address = Address.Create(country, line1, line2, city, state, zipCode);

        // Assert
        Assert.NotNull(address);
        Assert.Equal(country, address.Country);
        Assert.Equal(line1, address.Line1);
        Assert.Equal(line2, address.Line2);
        Assert.Equal(city, address.City);
        Assert.Equal(state, address.State);
        Assert.Equal(zipCode, address.ZipCode);
    }

    [Fact]
    public void Address_Create_Returns_Null_When_Any_Property_Is_Null_Or_Empty()
    {
        // Arrange
        var country = "Country";
        var line1 = "Line 1";
        var line2 = ""; // Propiedad vacía para forzar el retorno nulo
        var city = "City";
        var state = "State";
        var zipCode = "ZipCode";

        // Act
        var address = Address.Create(country, line1, line2, city, state, zipCode);

        // Assert
        Assert.Null(address);
    }

    [Fact]
    public void Location_Creation_With_Valid_Data_Succeeds()
    {
        // Arrange
        var id = new LocationId(Guid.NewGuid());
        var capacity = 10;
        var available = true;
        var name = "Location Name";
        var address = new Address("Country", "Line 1", "", "City", "State", "12345");
        var latitude = 40.730610;
        var longitude = -73.935242;
        var ubication = new Point(longitude, latitude) { SRID = 4326 };

        // Act
        var location = new Domain.Entities.Locations.Location(id, capacity, available, name, address, latitude, longitude, ubication);

        // Assert
        Assert.NotNull(location);
        Assert.Equal(id, location.Id);
        Assert.Equal(capacity, location.Capacity);
        Assert.Equal(available, location.Available);
        Assert.Equal(name, location.Name);
        Assert.Equal(address, location.Address);
        Assert.Equal(latitude, location.Latitude);
        Assert.Equal(longitude, location.Longitude);
        Assert.Equal(ubication, location.Ubication);
    }

    [Fact]
    public void Location_Creation_With_Invalid_Latitude_Throws_Exception()
    {
        // Arrange
        var id = new LocationId(Guid.NewGuid());
        var capacity = 10;
        var available = true;
        var name = "Location Name";
        var address = new Address("Country", "Line 1", "", "City", "State", "12345");
        var latitude = 100; // Invalid latitude value
        var longitude = -73.935242;
        var ubication = new Point(longitude, latitude) { SRID = 4326 };

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Domain.Entities.Locations.Location(id, capacity, available, name, address, latitude, longitude, ubication)
        );
    }

    [Fact]
    public void Location_UpdateLocation_Returns_Location_With_Correct_Properties()
    {
        // Arrange
        var id = Guid.NewGuid();
        var capacity = 10;
        var available = true;
        var name = "Location Name";
        var address = new Address("Country", "Line 1", "", "City", "State", "12345");
        var latitude = 40.730610;
        var longitude = -73.935242;

        // Act
        var location = Domain.Entities.Locations.Location.UpdateLocation(id, capacity, available, name, address, latitude, longitude);

        // Assert
        Assert.NotNull(location);
        Assert.IsType<Domain.Entities.Locations.Location>(location);
        Assert.Equal(id, location.Id!.value);
        Assert.Equal(capacity, location.Capacity);
        Assert.Equal(available, location.Available);
        Assert.Equal(name, location.Name);
        Assert.Equal(address, location.Address);
        Assert.Equal(latitude, location.Latitude);
        Assert.Equal(longitude, location.Longitude);
        Assert.NotNull(location.Ubication);
    }

    [Fact]
    public async Task SaveChangesAsync_Returns_IntValue()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var unitOfWork = new Mock<IUnitOfWork>();

        unitOfWork.Setup(uow => uow.SaveChangesAsync(cancellationToken)).ReturnsAsync(1);

        // Act
        var result = await unitOfWork.Object.SaveChangesAsync(cancellationToken);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task GetAll_Returns_All_Locations()
    {
        // Arrange
        var mockRepository = new Mock<ILocationRepository>();
        var expectedLocations = new List<Domain.Entities.Locations.Location>(); // Agrega algunas ubicaciones de prueba
        mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(expectedLocations);

        // Act
        var result = await mockRepository.Object.GetAll();

        // Assert
        Assert.Equal(expectedLocations, result);
    }
}
