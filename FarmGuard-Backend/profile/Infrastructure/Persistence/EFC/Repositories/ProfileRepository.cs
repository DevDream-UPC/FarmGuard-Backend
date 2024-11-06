using FarmGuard_Backend.profile.Domain.Model.Aggregate;
using FarmGuard_Backend.profile.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.profile.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<Profile>(context), IProfileRepository
{

    public Task<bool> GetProfileByEmail(string email)
    {
        return context.Set<Profile>().AnyAsync(p => p.Email.EAddress == email);
    }
}