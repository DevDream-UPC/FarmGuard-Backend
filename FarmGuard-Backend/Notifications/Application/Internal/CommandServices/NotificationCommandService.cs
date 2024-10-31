using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using FarmGuard_Backend.Notifications.Domain.Repositories;
using FarmGuard_Backend.Shared.Domain.Repositories;
using System.Threading.Tasks;
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
        
        /* Tu codigo
            public async Task<Notification> CreateNotificationAsync(string title, int animalId, string description,string state)
            {
                //ObjetoDato
                var notification = new Notification();
                ;

                await _notificationRepository.AddAsync(notification);
                await _unitOfWork.CompleteAsync();

                return notification;
            }
        */
        public async Task<Notification?> Handle(CreateNotificationCommand command)
        {
            try
            {
                //Reglas del Negocio =>
                //Verifiques si existe un animal con esa id,Y obtener los datos del animal
                //Verifiques si su temperatura no excede de lo normal
                //Vwerifiques que su ritmo cardiaco no este fuera de lo normal
                
                
                
                //CreaObjeto
                var notification =
                    new Notification(command.title, command.animalId, command.description, command.state);
                
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