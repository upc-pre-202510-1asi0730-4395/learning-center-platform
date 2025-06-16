namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Model.ValueObjects;

public record PersonName(string FirstName = "", string LastName = "")
{
    public string FullName => $"{FirstName} {LastName}".Trim();

    public override string ToString() => FullName;
    
}