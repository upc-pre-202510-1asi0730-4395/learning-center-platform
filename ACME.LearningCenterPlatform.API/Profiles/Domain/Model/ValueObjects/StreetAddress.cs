namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Model.ValueObjects;

public record StreetAddress(
    string Street = "",
    string Number = "",
    string City = "",
    string PostalCode = "",
    string Country = ""
)
{
    public StreetAddress(string street) : this(Street: street)
    {
    }

    public StreetAddress(string street, string number, string city, string postalCode)
        : this(Street: street, Number: number, City: city, PostalCode: postalCode)
    {
    }

    public string FullAddress => $"{Street} {Number}, {City}, {PostalCode}, {Country}".Trim();
}