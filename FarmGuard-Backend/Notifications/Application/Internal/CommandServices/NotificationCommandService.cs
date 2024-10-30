using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using FarmGuard_Backend.Notifications.Domain.Repositories;
using FarmGuard_Backend.Shared.Domain.Repositories;
using System.Threading.Tasks;

namespace FarmGuard_Backend.Notifications.Application.Internal.CommandServices
{
    // Servicio de comandos para manejar notificaciones
    public class NotificationCommandService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationCommandService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }

        // Método para crear una nueva notificación
        public async Task<Notification> CreateNotificationAsync(string title, int animalId, string description)
        {
            var notification = new Notification
            {
                Title = title,
                AnimalId = animalId,
                Description = description
            };

            await _notificationRepository.AddAsync(notification);
            await _unitOfWork.CompleteAsync();

            return notification;
        }
    }
}