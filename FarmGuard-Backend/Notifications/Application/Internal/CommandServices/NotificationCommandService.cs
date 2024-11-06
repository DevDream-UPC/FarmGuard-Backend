using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using FarmGuard_Backend.Notifications.Domain.Repositories;
using FarmGuard_Backend.Shared.Domain.Repositories;
using System.Threading.Tasks;
using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Notifications.Domain.Model.Commands;
using FarmGuard_Backend.Notifications.Domain.Services;

namespace FarmGuard_Backend.Notifications.Application.Internal.CommandServices
{
    // Servicio de comandos para manejar notificaciones
    public class NotificationCommandService:INotificationCommandService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationCommandService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }

        // Método para crear una nueva notificación

        public async Task<Notification?> Handle(CreateNotificationCommand command)
        {
            try
            {
            
                //CreaObjeto
                var notification =
                    new Notification(command.title, command.description, command.state,command.InventoryId);
                
                //Se guarda en la base de datos
                await _notificationRepository.AddAsync(notification);
                await _unitOfWork.CompleteAsync();

                return notification;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        
    }
}