namespace FarmGuard_Backend.Notifications.Interfaces.Rest.Resources;

public record NotificationResource(
    int Id, 
    string Title, 
    string Description,
    int AnimalId, 
    string state);