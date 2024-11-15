using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using System.Threading.Tasks;

namespace FarmGuard_Backend.Notifications.Domain.Repositories
{
    public interface INotificationRepository
    {
        Task AddAsync(Notification notification);
    }
}