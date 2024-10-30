using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using System.Threading.Tasks;

namespace FarmGuard_Backend.Notifications.Domain.Repositories
{
    // Interfaz para el repositorio de notificaciones
    public interface INotificationRepository
    {
        Task AddAsync(Notification notification); // Método para agregar una notificación de forma asíncrona
    }
}