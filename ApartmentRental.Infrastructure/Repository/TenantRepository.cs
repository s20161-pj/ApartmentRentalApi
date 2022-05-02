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
    public class TenantRepository : ITenantRepository
    {
        private readonly MainContext _mainContext;

        public TenantRepository(MainContext mainContext)
        {
            _mainContext = mainContext;
        }
        public async Task AddAsync(Tenant entity)
        {
            var isExist = await _mainContext.Tenant.AnyAsync(x => x.Id == entity.Id);

            if (isExist)
            {
                throw new Exception("Podany najemca już istnieje");
            }

            entity.DateOfCreation = DateTime.UtcNow;
            await _mainContext.AddAsync(entity);
            await _mainContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var tenantToDelete = await _mainContext.Tenant.SingleOrDefaultAsync(x => x.Id == id);
            if (tenantToDelete != null)
            {
                _mainContext.Tenant.Remove(tenantToDelete);
                await _mainContext.SaveChangesAsync();
            }
            throw new EntityNotFoundException();
        }

        public async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            var tenant = await _mainContext.Tenant.ToListAsync();
            return tenant;
        }

        public async Task<Tenant> GetByIdAsync(int id)
        {
            var tenant = await _mainContext.Tenant.SingleOrDefaultAsync(x => x.Id == id);
            if (tenant == null)
            {
                throw new EntityNotFoundException();
            }

            return tenant;
        }

        public async Task UpdateAsync(Tenant entity)
        {
            var tenantToUpdate = await _mainContext.Tenant.SingleOrDefaultAsync(x => x.Id == entity.Id);
            if (tenantToUpdate == null)
            {
                throw new EntityNotFoundException();
            }
            tenantToUpdate.Apartment = entity.Apartment;
            tenantToUpdate.AccountId = entity.AccountId;
            tenantToUpdate.Account = entity.Account;
            tenantToUpdate.DateOfUpdate = DateTime.UtcNow;
            await _mainContext.SaveChangesAsync();
        }
    }
}
