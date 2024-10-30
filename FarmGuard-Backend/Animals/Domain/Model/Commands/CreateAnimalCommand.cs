namespace FarmGuard_Backend.Animals.Domain.Model.Commands;

public record CreateAnimalCommand(
    string name, 
    string specie, 
    string urlIot, 
    string urlPhoto, 
    string location, 
    long hearRate,
    long temperature,
    int inventoryId
    );