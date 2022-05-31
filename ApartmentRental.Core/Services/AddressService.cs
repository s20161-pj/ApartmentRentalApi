namespace ApartmentRental.Core.Services
{
    using ApartmentRental.Infrastructure;
    using ApartmentRental.Infrastructure.Repository;

    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Address> GetAddressOrCreateAsync(string city, string zipCode, string street, string country,
            string buildingNumber,
            string apartmentNumber)
        {
            var address = await _addressRepository.GetAddressByItsAttributesAsync(country, city, zipCode, street,
               buildingNumber,
               apartmentNumber);
            if (address != null)
            {
                return address;
            }
            var newAdress = await _addressRepository.CreateAndGetAsync(new Address
            {
                Country = country,
                City = city,
                ZipCode = zipCode,
                Street = street,
                BuildingNumber = buildingNumber,
                AparmentNumber = apartmentNumber
            });
            return newAdress;
        }
    }
}
