using FarmGuard_Backend.Notifications.Domain.Model.Commands;
using FarmGuard_Backend.Notifications.Interfaces.Rest.Resources;

namespace FarmGuard_Backend.Notifications.Interfaces.Rest.Transform;

public class CreateNotificationCommandFromResourceAssembler
{
    public static CreateNotificationCommand ToCommandFromCreateResource(CreateNotificationResource resource)
    {
        return new CreateNotificationCommand(resource.Title,resource.Description,resource.state,resource.InventoryId);
    }
}