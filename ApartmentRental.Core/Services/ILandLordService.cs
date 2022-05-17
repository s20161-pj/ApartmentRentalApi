using ApartmentRental.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRental.Core.Services
{
   public interface ILandLordService
    {
        Task AddLandlordAsync (LandLordCreationRequestDto dto);
    }
}
