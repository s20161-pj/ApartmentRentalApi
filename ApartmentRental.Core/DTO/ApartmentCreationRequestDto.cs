using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRental.Core.DTO
{
    public class ApartmentCreationRequestDto
    {
        public decimal RentAmount { get; set; }
        public int NumberOfRooms { get; set; }
        public int SquareMeters { get; set; }
        public int Floor { get; set; }
        public bool isElevator { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string ApartmentNumber { get; set; }
        public string BuildingNumber { get; set; }
        public string Country { get; set; }
        public int LandLordId { get; set;}

    }
}
