using FarmGuard_Backend.Notifications.Domain.Model.ValueObjects;

namespace FarmGuard_Backend.Notifications.Domain.Model.Aggregates
{
    // Entidad Notification con propiedades básicas
    public class Notification
    {
        public Notification()
        {
            
        }

        public Notification(string title,int animalId, string description, string state)
        {
            Title = title;
            AnimalId= animalId;
            Description = description;
            State = ConvertStringToEnum(state);

        }
        public int Id { get; } // Identificador único de la notificación
        public string Title { get; private set; } // Título de la notificación
        public int AnimalId { get; private set; } // Identificador del animal asociado
        public string Description { get; private set; } // Descripción de la notificación
        public  EState State { get; private set; }
        
        public EState ConvertStringToEnum(string state)
        {
            if (Enum.TryParse<EState>(state, true, out var eState))
            {
                return eState;
            }
            else
            {
                throw new ArgumentException($"`{state}` is not a valid state`");
            }
        }
    }
}