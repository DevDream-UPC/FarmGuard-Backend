namespace FarmGuard_Backend.Notifications.Domain.Model.Aggregates
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AnimalId { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
    }
}