using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using FarmGuard_Backend.Notifications.Domain.Model.Commands;
using FarmGuard_Backend.Notifications.Domain.Services;
using FarmGuard_Backend.Notifications.Interfaces.Rest.Resources;
using FarmGuard_Backend.Notifications.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.Notifications.Interfaces.Rest;

[Controller]
[Route("/api/v1/notification")]
public class NotificationController(INotificationCommandService notificationCommandService): ControllerBase
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
}