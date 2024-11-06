using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.Animals.Interfaces.Rest.resources;
using FarmGuard_Backend.Animals.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FarmGuard_Backend.Animals.Interfaces.Rest;

[ApiController]
[Route("api/v1/animals")]
public class AnimalController(IAnimalCommandService animalCommandService, IAnimalQueryService animalQueryService):ControllerBase
{
    [HttpPost("{idInventory}")]
    public async Task<IActionResult> CreateAnimal([FromBody] CreateAnimalResource resource, int idInventory)
    {
        try
        {
            var createAnimalCommand = CreateAnimalCommandFromResourceAssembler.ToCommandFromResource(resource,idInventory);
            var animal = await animalCommandService.Handle(createAnimalCommand);
            
            if (animal == null) return BadRequest();

            var resourceResult = AnimalResourceFromEntityAssembler.ToResourceFromEntity(animal);
            return Ok(resourceResult);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new {message = "An error has occured!" + e.Message });
        }
    }

    [HttpGet("{idAnimal}")]
    public async Task<IActionResult> GetAnimalByIdAnimal(string idAnimal)
    {
        var animal = await animalQueryService.Handle(new GetAnimalBySerialNumberId(idAnimal));
        if(animal == null) return NotFound();
        var resource = AnimalResourceFromEntityAssembler.ToResourceFromEntity(animal);
        return Ok(resource);
    }

    [HttpPut("{idSerialAnimal}")]
    public async Task<IActionResult> PutAnimalById([FromBody] UpdateAnimalResource resource,string idSerialAnimal)
    {
        var updateAnimalCommand = new PutAnimalCommand(
            resource.Name,
            idSerialAnimal,
            resource.Specie.ToString(),
            resource.UrlIot,
            resource.UrlPhoto,
            resource.Location,
            resource.HearRate,
            resource.Temperature);
        var animal = await animalCommandService.Handle(updateAnimalCommand);
        
        return Ok(animal);
    }

    [HttpDelete("{idAnimal}")]
    public async Task<IActionResult> DeleteAnimalByAnimalSerialId(string idAnimal)
    {
        var animal = await animalCommandService.Handle(new DeleteAnimalByIdAnimalCommand(idAnimal));
        return Ok(animal);
    }

    [HttpGet("inventory/{idInventory}")]
    public async Task<IActionResult> GetAllAnimalsByInventory(int idInventory)
    {
        var animals = await animalQueryService.Handle(new GetAllAnimalsByIdInventory(idInventory));
        var resource = animals.Select(AnimalResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resource);
        /*
        var vaccines = await vaccineQueryService.Handle(new GetVaccinesByIdAnimal(serialAnimalId));
        var resources = vaccines.Select(VaccineResourceFromEntityAssembler.ToEntityFromResource);
        return Ok(resources);*/
    }

}

