namespace ApartmentRental.API.Controllers
{
    using ApartmentRental.Core.DTO;
    using ApartmentRental.Core.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class LandLordController : ControllerBase
    {
        private readonly ILandLordService _landlordService;

        public LandLordController(ILandLordService landlordService)
        {
            _landlordService = landlordService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateNewLandlordAccount([FromBody] LandLordCreationRequestDto dto)
        {
            await _landlordService.AddLandlordAsync(dto);
            return NoContent();
        }
    }
}
