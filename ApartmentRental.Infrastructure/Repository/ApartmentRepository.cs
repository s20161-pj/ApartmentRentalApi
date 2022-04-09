using ApartmentRental.Infrastructure.Context;

namespace ApartmentRental.Infrastructure.Repository;

public class ApartmentRepository : IApartmentRepository
{
    private readonly MainContext _mainContext;

    public ApartmentRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public Task<IEnumerable<Apartment>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Apartment> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Apartment entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Apartment entity)
    {
        throw new NotImplementedException();
    }

    public Task DeletedById(int id)
    {
        throw new NotImplementedException();
    }
}