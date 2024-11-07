namespace FarmGuard_Backend.Animals.Interfaces.Rest.resources;

public record CreateAnimalResource(
    string name,
    string specie,
    string urlIot,
    string urlPhoto,
    string location,
    long hearRate,
    long temperature
    );
