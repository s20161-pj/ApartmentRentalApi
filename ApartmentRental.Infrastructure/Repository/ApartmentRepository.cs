using ApartmentRental.Infrastructure.Context;
using ApartmentRental.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ApartmentRental.Infrastructure.Repository;

public class ApartmentRepository : IApartmentRepository
{
    private readonly MainContext _mainContext;

    public ApartmentRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<IEnumerable<Apartment>> GetAllAsync()
    {
        var apartments = await _mainContext.Apartment.ToListAsync();
        foreach (var apartment in apartments)
        {
            await _mainContext.Entry(apartment).Reference(x => x.Address).LoadAsync();
        }
        return apartments;
    }

    public async Task<Apartment> GetByIdAsync(int id)
    {
        var apartment = await _mainContext.Apartment.SingleOrDefaultAsync(x => x.Id == id);
        if (apartment != null)
        {
            await _mainContext.Entry(apartment).Reference(x => x.Address).LoadAsync();
            return apartment;
        }
        throw new EntityNotFoundException();
    }

    public async Task AddAsync(Apartment entity)
    {
        var isExist = await _mainContext.Apartment.AnyAsync(x =>
        x.Address.City == entity.Address.City
        && x.Address.Street == entity.Address.Street
        && x.Address.BuildingNumber == entity.Address.BuildingNumber
        && x.Address.ZipCode == entity.Address.ZipCode
        && x.Address.Country == entity.Address.Country
        && x.Address.AparmentNumber == entity.Address.AparmentNumber);

        if (isExist)
        {
            throw new Exception("Podany apartament już istnieje");
        }

        entity.DateOfCreation = DateTime.UtcNow;
        entity.DateOfUpdate = DateTime.UtcNow;
        _mainContext.Apartment.Add(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Apartment entity)
    {
        var apartmentToUpdate = await _mainContext.Apartment.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (apartmentToUpdate == null)
        {
            throw new EntityNotFoundException();
        }
        apartmentToUpdate.Floor = entity.Floor;
        apartmentToUpdate.IsElevator = entity.IsElevator;
        apartmentToUpdate.RentAmount = entity.RentAmount;
        apartmentToUpdate.SquareMeters = entity.SquareMeters;
        apartmentToUpdate.NumberOfRooms = entity.NumberOfRooms;
        apartmentToUpdate.DateOfUpdate = DateTime.UtcNow;
        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var apartmentToDelete = await _mainContext.Apartment.SingleOrDefaultAsync(x => x.Id == id);
        if (apartmentToDelete != null)
        {
            _mainContext.Apartment.Remove(apartmentToDelete);
            await _mainContext.SaveChangesAsync();
        }
        throw new EntityNotFoundException();
    }
}