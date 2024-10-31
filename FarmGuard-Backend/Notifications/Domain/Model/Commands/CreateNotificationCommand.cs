namespace FarmGuard_Backend.Notifications.Domain.Model.Commands;

public record CreateNotificationCommand(string title, int animalId, string description,string state);