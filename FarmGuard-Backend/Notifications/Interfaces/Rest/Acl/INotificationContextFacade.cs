namespace FarmGuard_Backend.Notifications.Interfaces.Rest.Acl;

public interface INotificationContextFacade
{
    Task<int> CreateNotification(string title, string description, string state,int inventoryId);
}