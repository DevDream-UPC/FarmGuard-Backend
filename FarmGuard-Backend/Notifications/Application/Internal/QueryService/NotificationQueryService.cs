using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using FarmGuard_Backend.Notifications.Domain.Model.queries;
using FarmGuard_Backend.Notifications.Domain.Repositories;
using FarmGuard_Backend.Notifications.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.Notifications.Application.Internal.QueryService;

public class NotificationQueryService(INotificationRepository notificationRepository,IUnitOfWork unitOfWork):INotificationQuerieService
{
    public async Task<IEnumerable<Notification>> Handle(GetAllNotificationsByIdInventory query)
    {
        //Falta verificar el id de inventario
        return await notificationRepository.GetAllNotificationsByInventoryId(query.InventoryId);
    }
}