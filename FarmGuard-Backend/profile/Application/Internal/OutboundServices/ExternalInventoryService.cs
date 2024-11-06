using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Interfaces.Acl;

namespace FarmGuard_Backend.profile.Application.Internal.OutboundServices;

public class ExternalInventoryService(IInventoryContextFacade inventoryContextFacade)
{
    public async Task<int?> CreateInventoryWithProfile(string profileName, int profileId)
    {
        var inventoryId = await inventoryContextFacade.CreateInventory(profileName, profileId);
        if(inventoryId == 0) return await Task.FromResult<int?>(null);
        return inventoryId;
    }
}