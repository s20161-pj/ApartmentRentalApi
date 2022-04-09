namespace ApartmentRental.Infrastructure;

public class Apartment : BaseEntity
{
    public decimal RentalAmount { get; set; }
    public int NumberOfRooms { get; set; }
    public int SquareMeters { get; set; }
    public int Floor { get; set; }
    public bool IsElement { get; set; }
    public int LandlordId { get; set; }
    public Landlord Landlord { get; set; }
    public int TenantId { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; }
    public IEnumerable<Image> Images { get; set; }
}