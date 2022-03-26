namespace ApartmentRental.Core.Entities;

public class Tenant:BaseEntity
{
    public Apartment Apartment { get; set; }
}