using FarmGuard_Backend.Animals.Application.Internal.QueryServices;
using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.Animals.Interfaces.Rest;

[ApiController]
[Route("api/v1/inventory")]
public class InventoryController(IInventoryCommandService inventoryCommandService,IInventoryQueryService inventoryQueryService):ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateInventory()
    {
        try
        {
            var createInventoryCommand = new CreateInventoryCommand();
            var inventory = await inventoryCommandService.Handle(createInventoryCommand);
            if (inventory == null) return BadRequest("Inventory is null");
            return Ok(inventory);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetInventoryById(int id)
    {
        try
        {
            var getInventoryByIdQuery = new GetInventoryByIdQueries(id);
            var inventory = await inventoryQueryService.Handle(getInventoryByIdQuery);
            if (inventory == null) return BadRequest($"Inventory not found with id: {id}");
            return Ok(inventory);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}