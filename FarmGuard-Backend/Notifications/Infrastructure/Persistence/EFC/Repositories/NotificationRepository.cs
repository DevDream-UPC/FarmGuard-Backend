using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using FarmGuard_Backend.Notifications.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;

namespace FarmGuard_Backend.Notifications.Infrastructure.Persistence.EFC.Repositories
{
    // Implementación del repositorio de notificaciones
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(AppDbContext context) : base(context)
        {
        }

        // Método para agregar una notificación a la base de datos
        public async Task AddAsync(Notification notification)
        {
            await Context.Set<Notification>().AddAsync(notification);
        }
    }
}