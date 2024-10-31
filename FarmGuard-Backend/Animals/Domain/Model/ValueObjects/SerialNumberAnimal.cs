namespace FarmGuard_Backend.Animals.Domain.Model.ValueObjects;

public record SerialNumberAnimal(string Number)
{
    public SerialNumberAnimal() : this(Guid.NewGuid().ToString())
    {
    }
}