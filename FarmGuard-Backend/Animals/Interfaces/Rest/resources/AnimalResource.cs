namespace FarmGuard_Backend.Animals.Interfaces.Rest.resources;

public record AnimalResource(
    int Id,
    string Name,
    string IdAnimal,
    string Specie,
    string UrlIot,
    string UrlPhoto,
    int InventoryId,
    string Location,
    long HearRate,
    long Temperature);