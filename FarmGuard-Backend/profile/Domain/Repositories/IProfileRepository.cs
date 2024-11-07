using FarmGuard_Backend.profile.Domain.Model.Aggregate;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.profile.Domain.Repositories;

/// <summary>
/// Profile repository interface 
/// </summary>
public interface IProfileRepository:IBaseRepository<Profile>
{
    /// <summary>
    ///Get a profile by email 
    /// </summary>
    /// <param name="email">
    /// The <see cref="string"/> email address to search for
    /// </param>
    /// <returns>
    /// The <see cref="bool"/> if found, otherwise false
    /// </returns>
    Task<bool> GetProfileByEmail(string email);
    
}