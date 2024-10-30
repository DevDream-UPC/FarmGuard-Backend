using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest;

[ApiController]
[Route("api/v1/vaccines")]
public class VaccineController(IVaccineCommandService vaccineCommandService):ControllerBase
{
    [HttpPost("{SerialAnimalId}")]
    public async Task<IActionResult> AddVaccineBySerialAnimalId([FromBody] CreateVaccineResource resource, string serialAnimalId)
    {
        var createVaccineCommand =
            CreateVaccineCommandFromResourceAssembler.ToCommandFromResource(resource, serialAnimalId);
        var vaccine = await vaccineCommandService.Handle(createVaccineCommand);
        
        System.Console.WriteLine(serialAnimalId);
        System.Console.WriteLine(vaccine);
        return Ok("Hola");
    }

    [HttpGet("{SerialAnimalId}")]
    public async Task<IActionResult> GetAllVaccinesBySerialAnimalId()
    {
        return Ok("Hola");
    }
}