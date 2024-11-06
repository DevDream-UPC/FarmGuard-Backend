using FarmGuard_Backend.MedicHistory.Application.Internal.QueryServices;
using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.MedicHistory.Infrastructure.Persistence.EFC.Repositories;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest;

[ApiController]
[Route("api/v1/vaccines")]
public class VaccineController(IVaccineCommandService vaccineCommandService,IVaccineQueryService vaccineQueryService):ControllerBase
{
    [HttpPost("{serialAnimalId}")]
    public async Task<IActionResult> AddVaccineBySerialAnimalId([FromBody] CreateVaccineResource resource, string serialAnimalId)
    {
        var createVaccineCommand =
            CreateVaccineCommandFromResourceAssembler.ToCommandFromResource(resource, serialAnimalId);
        var vaccine = await vaccineCommandService.Handle(createVaccineCommand);
        
        return Ok("Correcto");
    }

    [HttpGet("{serialAnimalId}")]
    public async Task<IActionResult> GetAllVaccinesByAnimalId(string serialAnimalId)
    {
        var vaccines = await vaccineQueryService.Handle(new GetVaccinesByIdAnimal(serialAnimalId));
        var resources = vaccines.Select(VaccineResourceFromEntityAssembler.ToEntityFromResource);
        return Ok(resources);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVaccineById(int id)
    {
        var vaccine = await vaccineCommandService.Handle(new DeleteVaccineCommand(id));
        return Ok(vaccine);
    }
}