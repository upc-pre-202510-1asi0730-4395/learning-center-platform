namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Commands;

/// <summary>
/// Create Profile Command 
/// </summary>
/// <param name="FirstName">
/// The first name of the profile.
/// </param>
/// <param name="LastName">
/// The last name of the profile.
/// </param>
/// <param name="Email">
/// The email address of the profile.
/// </param>
/// <param name="Street">
/// The street address of the profile.
/// </param>
/// <param name="Number">
/// The number of the street address for the profile.
/// </param>
/// <param name="City">
/// The city of the profile.
/// </param>
/// <param name="PostalCode">
/// The postal code of the profile.
/// </param>
/// <param name="Country">
/// The country of the profile.
/// </param>
public record CreateProfileCommand( string FirstName, string LastName, string Email, string Street, string Number, string City, string PostalCode, string Country);