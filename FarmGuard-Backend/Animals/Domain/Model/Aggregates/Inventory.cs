namespace FarmGuard_Backend.Animals.Domain.Model.Aggregates;

public class Inventory
{
    public Inventory()
    {
        
    }
    public Inventory(string name)
    {
        Name = name;
        Animals = new List<Animal>();
    }
    
    
    
    public int Id { get; }
    
    public string Name { get; private set; }
    public ICollection<Animal> Animals { get; private set; }
        
}