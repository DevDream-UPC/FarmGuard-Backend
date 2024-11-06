using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using System.Threading.Tasks;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.Notifications.Domain.Repositories
{
    // Interfaz para el repositorio de notificaciones
    public interface INotificationRepository:IBaseRepository<Notification>
    {
        Task<IEnumerable<Notification>> GetAllNotificationsByInventoryId(int inventoryId);
    }
}