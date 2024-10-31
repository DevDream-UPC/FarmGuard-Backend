using FarmGuard_Backend.Animals.Domain.Model.Aggregates;

namespace FarmGuard_Backend.MedicHistory.Domain.Model.Entities;

public class Vaccine
{
    public Vaccine(){}

    public Vaccine(string name, string description, DateTime date, int animalId)
    {
        Name = name;
        Description = description;
        Date = date;
        AnimalId = animalId;
    }
    
    public int Id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    
    public int AnimalId { get;  private set; }
    
    public Animal Animal { get; private set; }
}