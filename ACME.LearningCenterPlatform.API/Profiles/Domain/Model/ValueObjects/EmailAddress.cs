namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Model.ValueObjects;

public record EmailAddress(string Address = "")
{
    public override string ToString() => Address;
}
