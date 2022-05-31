
using ApartmentRental.Core.DTO;
using ApartmentRental.Infrastructure;
using ApartmentRental.Infrastructure.Repository;

namespace ApartmentRental.Core.Services
{
    public class LandLordService : ILandLordService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILandlordRepository _landlordRepository;

        public LandLordService(IAddressRepository addressRepository, ILandlordRepository landlordRepository)
        {
            _addressRepository = addressRepository;
            _landlordRepository = landlordRepository;
        }

        public async Task AddLandlordAsync(LandLordCreationRequestDto dto)
        {
            var address = await _addressRepository.FindAndGetAsync(new Address { 
                AparmentNumber = dto.ApartmentNumber,
                Street = dto.Street,
                BuildingNumber = dto.NumberOfBuilding,
                City = dto.City,
                Country = dto.Country,
                ZipCode = dto.ZipCode,
            });

            await _landlordRepository.AddAsync(new Landlord
            {
                Account = new Account
                {
                    AddressId = (int)address.Id,
                    FirstName = dto.Name,
                    Email = dto.Email,
                    IsAccountActive = true,
                    LastName = dto.Surname,
                    PhoneNumber = dto.PhoneNumber,
                    DateOfUpdate = DateTime.Now,
                    DateOfCreation = DateTime.Now,
                },
                DateOfCreation = DateTime.Now,
                DateOfUpdate = DateTime.Now
            });
        }
    }
}
