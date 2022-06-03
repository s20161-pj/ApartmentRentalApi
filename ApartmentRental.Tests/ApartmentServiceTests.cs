namespace ApartmentRental.Tests
{
    using ApartmentRental.API.Services;
    using ApartmentRental.Core.Services;
    using ApartmentRental.Infrastructure;
    using ApartmentRental.Infrastructure.Repository;
    using FluentAssertions;
    using Moq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class ApartmentServiceTests
    {
        [Fact]
        public async Task GetTheCheapestApartmentAsync_ShouldReturnNull_WhenApartmentsCollectionIsNull()
        {
            var sut = new ApartmentService(Mock.Of<IApartmentRepository>(), Mock.Of<ILandlordRepository>(), Mock.Of<IAddressService>());
            var result = await sut.GetTheCheapestApartmentAsync();
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetTheCheapestApartmentAsync_ShouldReturnTheCheapestApartment()
        {

            var apartments = new List<Apartment>
            {
                new()
                {
                    Address=new Address()
                    {
                        City="Gdañsk",
                        Country="Poland",
                        Street="Grunwaldzka",
                        AparmentNumber="1",
                        BuildingNumber="2",
                        ZipCode="80-000",
                    },
                    Floor=1,
                    RentAmount=2000,
                    SquareMeters=45,
                    NumberOfRooms=3,
                    IsElevator=true,
                },
                new()
                {
                    Address=new Address()
                    {
                        City ="Gdynia",
                        Country ="Poland",
                        Street ="Wielkopolska",
                        AparmentNumber="2",
                        BuildingNumber ="1",
                        ZipCode ="80-001"
                    },
                    Floor=2,
                    RentAmount=1999,
                    SquareMeters=40,
                    NumberOfRooms=2,
                }
            };
            var apartmentRepositoryMock = new Moq.Mock<IApartmentRepository>();
            apartmentRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(apartments);
            var sut = new ApartmentService(apartmentRepositoryMock.Object, Mock.Of<ILandlordRepository>(), Mock.Of<IAddressService>());
            var result = await sut.GetTheCheapestApartmentAsync();

            result.Should().NotBeNull();
            result.City.Should().Be("Gdynia");
            result.Street.Should().Be("Wielkopolska");
            result.RentAmount.Should().Be(1999);
            result.SquareMeters.Should().Be(40);
            result.NumberOfRooms.Should().Be(2);
            result.IsElevatorInBuilding.Should().BeFalse();

        }

        [Fact]
        public async Task GetAllApartmensBasicInfosAsync_ShouldReturnCollectionOfApartments()
        {
            var apartments = new List<Apartment>
            {
                new()
                {
                    Address=new Address()
                    {
                        City="Gdañsk",
                        Country="Poland",
                        Street="Grunwaldzka",
                        AparmentNumber="1",
                        BuildingNumber="2",
                        ZipCode="80-000",
                    },
                    Floor=1,
                    RentAmount=2000,
                    SquareMeters=45,
                    NumberOfRooms=3,
                    IsElevator=true,
                },
                new()
                {
                    Address=new Address()
                    {
                        City ="Gdynia",
                        Country ="Poland",
                        Street ="Wielkopolska",
                        AparmentNumber="2",
                        BuildingNumber ="1",
                        ZipCode ="80-001"
                    },
                    Floor=2,
                    RentAmount=1999,
                    SquareMeters=40,
                    NumberOfRooms=2,
                }
            };
            var apartmentRepositoryMock = new Moq.Mock<IApartmentRepository>();
            apartmentRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(apartments);
            var sut = new ApartmentService(apartmentRepositoryMock.Object, Mock.Of<ILandlordRepository>(), Mock.Of<IAddressService>());
            var result = await sut.GetAllApartmensBasicInfosAsync();
            result.Should().NotBeNull();
            result.Should().HaveCount(apartments.Count);
        }

    }
}
