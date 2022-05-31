using ApartmentRental.Core.DTO;
using ApartmentRental.Core.Services;
using ApartmentRental.Infrastructure;
using ApartmentRental.Infrastructure.Repository;

namespace ApartmentRental.API.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly ILandlordRepository _landlordRepository;
        private readonly IAddressService _addressService;

        public ApartmentService(IApartmentRepository apartmentRepository, ILandlordRepository landlordRepository, IAddressService addressService)
        {
            _apartmentRepository = apartmentRepository;
            _landlordRepository = landlordRepository;
            _addressService = addressService;
        }

        public async Task AddNewApartmentToExistingLandLordAsync(ApartmentCreationRequestDto dto)
        {
            var landlord = await _landlordRepository.GetByIdAsync(dto.LandLordId);
            var address = await _addressService.GetAddressOrCreateAsync(dto.Country,
                dto.City, dto.ZipCode, dto.Street,
                dto.BuildingNumber, dto.ApartmentNumber);

            await _apartmentRepository.AddAsync(new Apartment
            {
                Address = address,
                AddressId = (int)address.Id,
                Floor = dto.Floor,
                LandlordId = (int)landlord.Id,
                Landlord = landlord,
                IsElevator = dto.isElevator,
                RentAmount = dto.RentAmount,
                SquareMeters = dto.SquareMeters,
                NumberOfRooms = dto.NumberOfRooms
            });

        }
        public async Task<IEnumerable<ApartmentBasicInformationResponseDto>> GetAllApartmensBasicInfosAsync()
        {
            var apartments = await _apartmentRepository.GetAllAsync();
            return apartments.Select(x => new ApartmentBasicInformationResponseDto(
                x.RentAmount,
                x.NumberOfRooms,
                x.SquareMeters,
                x.IsElevator,
                x.Address.City,
                x.Address.Street));
        }
        public async Task<ApartmentBasicInformationResponseDto?> GetTheCheapestApartmentAsync()
        {
            var apartments = await _apartmentRepository.GetAllAsync();
            var cheapestOne = apartments.MinBy(x => x.RentAmount);
            if (cheapestOne is null) return null;
            return new ApartmentBasicInformationResponseDto(
                cheapestOne.RentAmount,
                cheapestOne.NumberOfRooms,
                cheapestOne.SquareMeters,
                cheapestOne.IsElevator,
                cheapestOne.Address.City,
                cheapestOne.Address.Street);
        }
    }
}
