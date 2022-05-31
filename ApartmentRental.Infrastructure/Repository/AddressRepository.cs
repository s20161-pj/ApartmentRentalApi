﻿using ApartmentRental.Infrastructure.Context;
using ApartmentRental.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRental.Infrastructure.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly MainContext _mainContext;

        public AddressRepository(MainContext mainContext)
        {
            _mainContext = mainContext;
        }
        public async Task AddAsync(Address entity)
        {
          var isExist = await _mainContext.Address.AnyAsync(x =>
          x.City == entity.City
          && x.Street == entity.Street
          && x.BuildingNumber == entity.BuildingNumber
          && x.AparmentNumber == entity.AparmentNumber
          && x.ZipCode == entity.ZipCode
          && x.Country == entity.Country);

            if (isExist)
            {
                throw new Exception("Podany adres już istnieje");
            }
            entity.DateOfCreation = DateTime.UtcNow;
            await _mainContext.Address.AddAsync(entity);
            await _mainContext.SaveChangesAsync();
        }

        public async Task<Address> CreateAndGetAsync(Address address)
        {
            address.DateOfCreation = DateTime.UtcNow;
            address.DateOfUpdate = DateTime.UtcNow;
            await _mainContext.AddAsync(address);
            await _mainContext.SaveChangesAsync();
            return address;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var addressToDelete = await _mainContext.Address.SingleOrDefaultAsync(x => x.Id == id);
            if (addressToDelete != null)
            {
                _mainContext.Address.Remove(addressToDelete);
                await _mainContext.SaveChangesAsync();
            }
            throw new EntityNotFoundException();
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            var address = await _mainContext.Address.ToListAsync();
           
            return address;
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            var address = await _mainContext.Address.SingleOrDefaultAsync(x => x.Id == id);
            if (address == null)
            {
                throw new EntityNotFoundException();
            }

            return address;
        }

        public async Task UpdateAsync(Address entity)
        {
            var addressToUpdate = await _mainContext.Address.SingleOrDefaultAsync(x => x.Id == entity.Id);
            if (addressToUpdate == null)
            {
                throw new EntityNotFoundException();
            }
            addressToUpdate.Street = entity.Street;
            addressToUpdate.AparmentNumber = entity.AparmentNumber;
            addressToUpdate.BuildingNumber = entity.BuildingNumber;
            addressToUpdate.City = entity.City;
            addressToUpdate.ZipCode = entity.ZipCode;
            addressToUpdate.Country = entity.Country;
            addressToUpdate.DateOfUpdate = DateTime.UtcNow;
            await _mainContext.SaveChangesAsync();
        }

        public async Task<Address?> GetAddressByItsAttributesAsync(string country, string city, string zipCode, string street,
             string buildingNumber,
             string apartmentNumber)

        {
            var address = await _mainContext.Address.FirstOrDefaultAsync(x =>
            x.Country == country && x.City == city && x.ZipCode == zipCode && x.Street == street &&
            x.BuildingNumber == buildingNumber && x.AparmentNumber == apartmentNumber);
            return address;
        }

        public async Task<Address?> FindAndGetAsync(Address entity)
        {
          var address = await _mainContext.Address.FirstOrDefaultAsync(x =>
              x.City == entity.City
              && x.Street == entity.Street
              && x.BuildingNumber == entity.BuildingNumber
              && x.AparmentNumber == entity.AparmentNumber
              && x.ZipCode == entity.ZipCode
              && x.Country == entity.Country
            );

            if(address != null)
            {
                return address;
            }

            entity.DateOfCreation = DateTime.UtcNow;
            entity.DateOfUpdate = DateTime.UtcNow;
            await _mainContext.AddAsync(entity);
            await _mainContext.SaveChangesAsync();
            return entity;
        }
    }
}
