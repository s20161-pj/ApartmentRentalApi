using ApartmentRental.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRental.Core.Services
{
    public interface IAddressService
    {
        public Task<Address> GetAddressOrCreateAsync(string country, string city, string zipCode, string street, string buildingNumber, string apartmentNumber);
     }
}
