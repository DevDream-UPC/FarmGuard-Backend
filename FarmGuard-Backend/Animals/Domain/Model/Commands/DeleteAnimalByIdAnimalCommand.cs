using System.Windows.Input;

namespace FarmGuard_Backend.Animals.Domain.Model.Commands;

public record DeleteAnimalByIdAnimalCommand(string AnimalId);