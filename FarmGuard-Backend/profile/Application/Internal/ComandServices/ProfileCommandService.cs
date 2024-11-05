using FarmGuard_Backend.profile.Domain.Model.Aggregate;
using FarmGuard_Backend.profile.Domain.Model.Commands;
using FarmGuard_Backend.profile.Domain.Repositories;
using FarmGuard_Backend.profile.Domain.Services;

namespace FarmGuard_Backend.profile.Application.Internal.ComandServices;

public class ProfileCommandService(IProfileRepository profileRepository):IProfileCommandService
{
    
    public Task<Profile?> Handle(CreateProfileCommand command)
    {
        return null;
    }

    public Task<Profile?> Handle(UpdateProfileCommand command)
    {
        return null;
    }

    public Task<Profile?> Handle(DeleteProfileByIdCommand command)
    {
        return null;
    }
}