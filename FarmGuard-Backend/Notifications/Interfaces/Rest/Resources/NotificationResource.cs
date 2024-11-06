namespace FarmGuard_Backend.Notifications.Interfaces.Rest.Resources;

public record NotificationResource(
    int Id, 
    string Title, 
    string Description,
    string state);