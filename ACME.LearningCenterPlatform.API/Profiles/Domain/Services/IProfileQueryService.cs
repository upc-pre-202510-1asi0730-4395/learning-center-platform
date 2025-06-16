using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Queries;

namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Services;

/// <summary>
/// Profile query service 
/// </summary>
public interface IProfileQueryService
{
    /// <summary>
    /// Handle get all profiles 
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllProfilesQuery"/> query
    /// </param>
    /// <returns>
    /// A list of <see cref="Profile"/> objects
    /// </returns>
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
    
    /// <summary>
    /// Handle get profile by email 
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetProfileByEmailQuery"/> query
    /// </param>
    /// <returns>
    /// A <see cref="Profile"/> object or null
    /// </returns>
    Task<Profile?> Handle(GetProfileByEmailQuery query);
    
    /// <summary>
    /// Handle get profile by id 
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetProfileByIdQuery"/> query
    /// </param>
    /// <returns><
    /// A <see cref="Profile"/> object or null
    /// /returns>
    Task<Profile?> Handle(GetProfileByIdQuery query);
}