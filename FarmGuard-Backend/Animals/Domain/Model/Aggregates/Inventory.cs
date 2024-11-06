using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using FarmGuard_Backend.profile.Domain.Model.Aggregate;

namespace FarmGuard_Backend.Animals.Domain.Model.Aggregates;

public class Inventory
{
    public Inventory()
    {
        
    }
    public Inventory(string name,int idProfile)
    {
        Name = name;
        Animals = new List<Animal>();
        ProfileId = idProfile;
        Notifications = new List<Notification>();
        
    }
    
    
    
    public int Id { get; }
    
    public string Name { get; private set; }
    public ICollection<Animal> Animals { get; private set; }
    
    public ICollection<Notification> Notifications { get; private set; }
    
    public int ProfileId { get; private set; }
    
    public Profile Profile { get; private set; }
        
}