namespace FarmGuard_Backend.Notifications.Domain.Model.Commands;

public record CreateNotificationCommand(string title, string description,string state,int InventoryId);