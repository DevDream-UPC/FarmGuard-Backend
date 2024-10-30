namespace FarmGuard_Backend.Notifications.Domain.Model.Aggregates
{
    // Entidad Notification con propiedades básicas
    public class Notification
    {
        public int Id { get; set; } // Identificador único de la notificación
        public string Title { get; set; } // Título de la notificación
        public int AnimalId { get; set; } // Identificador del animal asociado
        public string Description { get; set; } // Descripción de la notificación
    }
}