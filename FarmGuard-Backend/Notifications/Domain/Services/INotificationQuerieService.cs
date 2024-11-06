using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using FarmGuard_Backend.Notifications.Domain.Model.queries;

namespace FarmGuard_Backend.Notifications.Domain.Services;

public interface INotificationQuerieService
{
    Task<IEnumerable<Notification>> Handle(GetAllNotificationsByIdInventory query);
}