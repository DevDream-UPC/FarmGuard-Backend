using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using FarmGuard_Backend.Notifications.Interfaces.Rest.Resources;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FarmGuard_Backend.Notifications.Interfaces.Rest.Transform;

public class NotificationResourceFromEntityAssembler
{
    public static NotificationResource ToEntityFromResource(Notification entity)
    {
        return new NotificationResource(entity.Id, entity.Title, entity.Description, entity.State.ToString());
    }
}