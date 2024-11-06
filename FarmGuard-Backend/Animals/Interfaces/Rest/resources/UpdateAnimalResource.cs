namespace FarmGuard_Backend.Animals.Interfaces.Rest.resources;

public record UpdateAnimalResource(
    string Name,
    string Specie,
    string UrlIot,
    string UrlPhoto,
    string Location,
    long HearRate,
    long Temperature);