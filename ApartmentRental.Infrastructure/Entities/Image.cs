namespace ApartmentRental.Infrastructure;
public class Image : BaseEntity
{
    public byte[] Data { get; set; }
    public int ApartmentId { get; set; }
    public Apartment Apartment { get; set; }
}