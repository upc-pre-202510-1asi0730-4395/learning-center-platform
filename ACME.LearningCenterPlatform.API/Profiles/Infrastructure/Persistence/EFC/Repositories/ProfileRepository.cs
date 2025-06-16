using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.ValueObjects;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ACME.LearningCenterPlatform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Profile repository implementation  
/// </summary>
/// <param name="context">
/// The database context
/// </param>
public class ProfileRepository(AppDbContext context) 
    : BaseRepository<Profile>(context), IProfileRepository
{
    /// <inheritdoc />
    public async Task<Profile?> FindProfileByEmailAsync(EmailAddress email)
    {
        return Context.Set<Profile>().FirstOrDefault(p => p.Email == email);
    }
}