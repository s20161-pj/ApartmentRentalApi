using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRental.Infrastructure.Repository
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<int> GetAddressIdByItsAttributesAsync(string country, string city, string zipCode, string street, string buildingNumber, string apartmentNumber);

        Task<Address> CreateAndGetAsync(Address address);
        Task<Address?> FindAndGetAsync(Address address);
    }
}