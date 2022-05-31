
namespace ApartmentRental.API.Controllers
{
    using ApartmentRental.API.Services;
    using ApartmentRental.Core.DTO;
    using ApartmentRental.Infrastructure.Exceptions;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]

    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult>CreateNewApartment([FromBody] ApartmentCreationRequestDto dto)
        {
            try
            {
                await _apartmentService.AddNewApartmentToExistingLandLordAsync(dto);
            }
            catch (EntityNotFoundException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpGet("GetAll")]
        public async Task <IActionResult> GetAll()
        {
            return Ok(await _apartmentService.GetAllApartmensBasicInfosAsync());
        }
        [HttpGet("GetTheCheapest")]
        public async Task<IActionResult> GetCheapestApartmentAsync()
        {
            var apartment = await _apartmentService.GetAllApartmensBasicInfosAsync();
            return Ok(apartment);
        }

    }
}
