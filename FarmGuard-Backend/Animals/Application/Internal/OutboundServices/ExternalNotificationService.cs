using FarmGuard_Backend.Notifications.Interfaces.Rest.Acl;

namespace FarmGuard_Backend.Animals.Application.Internal.OutboundServices;

public class ExternalNotificationService(INotificationContextFacade notificationContextFacade)
{
    public async Task<int?> CreateNotification(string title, string description, string state, int inventoryId)
    {
        var notificationId = await notificationContextFacade.CreateNotification(title,description,state,inventoryId);
        if (notificationId == 0) return await Task.FromResult<int?>(null);
        return notificationId;
        
    }
}