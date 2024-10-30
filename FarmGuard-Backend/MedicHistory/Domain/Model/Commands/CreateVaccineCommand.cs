namespace FarmGuard_Backend.MedicHistory.Domain.Model.Commands;

public record CreateVaccineCommand(string SerialAnimalId,string name, string description, DateTime date);