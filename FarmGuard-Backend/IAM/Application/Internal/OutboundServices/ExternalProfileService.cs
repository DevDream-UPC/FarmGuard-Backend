using FarmGuard_Backend.profile.Interfaces.Acl;

namespace FarmGuard_Backend.IAM.Application.Internal.OutboundServices;

public class ExternalProfileService(IProfileContextFacade profileContextFacade)
{
    public async Task<int> CreateProfileWithUser(string firstName, string lastName, string email, string urlPhoto,int userId)
    {
        var profileId = await profileContextFacade.CreateProfile(firstName, lastName, email, urlPhoto,userId);
        return profileId;
    }

    public async Task<int> GetInventoryId(int profileId)
    {
        var inventoryId = await profileContextFacade.GetProfileById(profileId);
        return inventoryId;

    }
}