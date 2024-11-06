using FarmGuard_Backend.Notifications.Domain.Model.Commands;
using FarmGuard_Backend.Notifications.Domain.Services;

namespace FarmGuard_Backend.Notifications.Interfaces.Rest.Acl.Services;

public class NotificationContextFacade(INotificationCommandService notificationCommandService):INotificationContextFacade
{
    public async Task<int> CreateNotification(string title, string description, string state, int inventoryId)
    {
        var createNotificationCommand = new CreateNotificationCommand(title,description,state,inventoryId);
        
        var notification = await notificationCommandService.Handle(createNotificationCommand);

        return notification?.Id ?? 0;
    }
}