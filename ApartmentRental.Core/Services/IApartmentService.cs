using ApartmentRental.Core.DTO;

namespace ApartmentRental.API.Services
{
    public interface IApartmentService
    {
        Task<IEnumerable<ApartmentBasicInformationResponseDto>> GetAllApartmensBasicInfosAsync();
        Task AddNewApartmentToExistingLandLordAsync(ApartmentCreationRequestDto dto);
        Task<ApartmentBasicInformationResponseDto> GetTheCheapestApartmentAsync();
    }
  
}
