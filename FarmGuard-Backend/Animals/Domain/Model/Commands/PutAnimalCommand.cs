namespace FarmGuard_Backend.Animals.Domain.Model.Commands;

public record PutAnimalCommand(
    string Name,
    string AnimalId,
    string Specie,
    string UrlIot,
    string UrlPhoto,
    string Location,
    long HearRate,
    long Temperature
    );