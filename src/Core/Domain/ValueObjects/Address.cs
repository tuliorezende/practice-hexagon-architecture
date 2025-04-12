namespace Domain.ValueObjects;

public class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, string state, string zipCode, string country)
    {
        this.Street = street;
        this.City = city;
        this.State = state;
        this.ZipCode = zipCode;
        this.Country = country;
    }
}