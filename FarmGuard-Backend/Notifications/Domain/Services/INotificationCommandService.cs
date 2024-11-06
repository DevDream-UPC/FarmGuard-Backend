using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using FarmGuard_Backend.Notifications.Domain.Model.Commands;

namespace FarmGuard_Backend.Notifications.Domain.Services;

public interface INotificationCommandService
{
    Task<Notification?> Handle(CreateNotificationCommand command);
    
}