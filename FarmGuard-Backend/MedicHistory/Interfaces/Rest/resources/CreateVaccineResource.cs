namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

public record CreateVaccineResource(
    string name,
    string description,
    DateTime date_expiration);