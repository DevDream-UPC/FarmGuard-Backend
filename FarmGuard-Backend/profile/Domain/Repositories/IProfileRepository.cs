using FarmGuard_Backend.profile.Domain.Model.Aggregate;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.profile.Domain.Repositories;

public interface IProfileRepository:IBaseRepository<Profile>
{
    Task<Profile?> GetProfileByEmail(string email);
    
}