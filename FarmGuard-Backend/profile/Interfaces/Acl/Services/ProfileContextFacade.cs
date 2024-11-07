using FarmGuard_Backend.profile.Domain.Model.Commands;
using FarmGuard_Backend.profile.Domain.Model.Queries;
using FarmGuard_Backend.profile.Domain.Services;

namespace FarmGuard_Backend.profile.Interfaces.Acl.Services;

public class ProfileContextFacade(IProfileCommandService profileCommandService,IProfileQueryService profileQueryService):IProfileContextFacade
{
    public async Task<int> CreateProfile(string firstName, string lastName, string email, string urlPhoto,int userId)
    {
        var createProfileCommand = new CreateProfileCommand(firstName, lastName, email, urlPhoto,userId);
        var profile = await profileCommandService.Handle(createProfileCommand);

        return profile?.Id ?? 0;
    }

    public async Task<int> GetProfileById(int id)
    {
        var getProfileByIdQuery = new GetProfileByIdQuery(id);
        var profile = await profileQueryService.Handle(getProfileByIdQuery);

        return profile?.InventoryId ?? 0;
    }
}