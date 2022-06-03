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

    public class AddressServiceTests
    {
        [Fact]
        public async Task GetAddressByItsAttributesAsync_ShouldReturnProperAddress()
        {
            var address = new Address()
            {
                City = "Gdynia",
                Country = "Poland",
                Street = "Wielkopolska",
                AparmentNumber = "2",
                BuildingNumber = "1",
                ZipCode = "80-001"
            };

            var addressRepositoryMock = new Moq.Mock<IAddressRepository>();
            addressRepositoryMock.Setup(x => x.GetAddressByItsAttributesAsync(address.Country, address.City, address.ZipCode, address.Street, address.BuildingNumber, address.AparmentNumber)).ReturnsAsync(address);
            var sut = new AddressService(addressRepositoryMock.Object);

            //string city, string zipCode, string street, string country,string buildingNumber, string apartmentNumber
            var result = await sut.GetAddressOrCreateAsync("Gdynia", "80-001", "Wielkopolska", "Poland", "1", "2");

            result.Should().NotBeNull();
            result.City.Should().Be("Gdynia");
        }
    }
}
