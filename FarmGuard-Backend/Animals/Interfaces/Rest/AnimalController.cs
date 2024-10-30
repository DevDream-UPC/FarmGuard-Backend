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
    [HttpPost]
    public async Task<IActionResult> CreateAnimal([FromBody] CreateAnimalResource resource)
    {
        try
        {
            var createAnimalCommand = CreateAnimalCommandFromResourceAssembler.ToCommandFromResource(resource);
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
}

