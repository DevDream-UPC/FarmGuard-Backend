namespace FarmGuard_Backend.Notifications.Interfaces.Rest.Resources;

public record CreateNotificationResource(
    string Title, 
    string Description,
    int InventoryId, 
    string state);