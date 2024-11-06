using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using FarmGuard_Backend.Notifications.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;

namespace FarmGuard_Backend.Notifications.Infrastructure.Persistence.EFC.Repositories
{
    // Implementación del repositorio de notificaciones
    public class NotificationRepository (AppDbContext context): BaseRepository<Notification>(context), INotificationRepository
    {
        public async Task<IEnumerable<Notification>> GetAllNotificationsByInventoryId(int inventoryId)
        {
            return await Context.Set<Notification>()
                .Where(n => n.InventoryId == inventoryId)
                .ToListAsync();
        }
    }
}