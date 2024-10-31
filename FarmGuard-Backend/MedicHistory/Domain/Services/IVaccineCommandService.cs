using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;

namespace FarmGuard_Backend.MedicHistory.Domain.Services;

public interface IVaccineCommandService
{
    Task<Vaccine?> Handle(CreateVaccineCommand command);
    Task<Vaccine?> Handle(DeleteVaccineCommand command);
}