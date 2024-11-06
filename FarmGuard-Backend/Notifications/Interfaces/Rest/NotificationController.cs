using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using FarmGuard_Backend.Notifications.Domain.Model.Commands;
using FarmGuard_Backend.Notifications.Domain.Model.queries;
using FarmGuard_Backend.Notifications.Domain.Services;
using FarmGuard_Backend.Notifications.Interfaces.Rest.Resources;
using FarmGuard_Backend.Notifications.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.Notifications.Interfaces.Rest;

[Controller]
[Route("/api/v1/notifications")]
public class NotificationController(INotificationCommandService notificationCommandService,INotificationQuerieService notificationQuerieService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateNotification([FromBody]CreateNotificationResource createResource)
    {
        
        //Crear el comando => transformando el createrresource a command
        var createNotificationCommand =
            CreateNotificationCommandFromResourceAssembler.ToCommandFromCreateResource(createResource);

        //Crear la notificaion y obtener el objeto
        var notification = await notificationCommandService.Handle(createNotificationCommand);
        
        if (notification == null) return BadRequest();
        
        //Tranformar la entidad en un recurso
        var resource =  NotificationResourceFromEntityAssembler.ToEntityFromResource(notification);
        
        
        //Expones el recurso
        return Ok(resource);
    }

    [HttpGet("{inventoryId}")]
    public async Task<IActionResult> GetAllNotificationsByIdInventory(int inventoryId)
    {
        var notifications = await notificationQuerieService.Handle(new GetAllNotificationsByIdInventory(inventoryId));
        var resource = notifications.Select(NotificationResourceFromEntityAssembler.ToEntityFromResource);
        return Ok(resource);
    }
}