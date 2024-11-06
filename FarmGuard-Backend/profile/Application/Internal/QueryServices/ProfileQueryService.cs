using FarmGuard_Backend.profile.Domain.Model.Aggregate;
using FarmGuard_Backend.profile.Domain.Model.Queries;
using FarmGuard_Backend.profile.Domain.Repositories;
using FarmGuard_Backend.profile.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.profile.Application.Internal.QueryServices;

public class ProfileQueryService(IProfileRepository profileRepository,IUnitOfWork unitOfWork):IProfileQueryService
{
    public async Task<Profile?> Handle(GetProfileByIdQuery query)
    {
        return await profileRepository.FindByIdAsync(query.id);
    }

    public Task<Profile?> Handle(GetProfileByEmailAddressQuery query)
    {
        throw new NotImplementedException();
    }
}