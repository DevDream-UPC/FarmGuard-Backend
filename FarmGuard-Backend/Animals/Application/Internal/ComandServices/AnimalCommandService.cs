using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Domain.Model.ValueObjects;
using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.Notifications.Application.Internal.CommandServices;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.Animals.Application.Internal.ComandServices
{
    public class AnimalCommandService : IAnimalCommandService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly NotificationCommandService _notificationCommandService;
        private const double PermittedTemperatureLevel = 38.5;

        public AnimalCommandService(IAnimalRepository animalRepository, IUnitOfWork unitOfWork, NotificationCommandService notificationCommandService)
        {
            _animalRepository = animalRepository;
            _unitOfWork = unitOfWork;
            _notificationCommandService = notificationCommandService;
        }

        public async Task<Animal?> Handle(CreateAnimalCommand command)
        {
            try
            {
                var animal = new Animal(
                    command.Name,
                    command.Specie,
                    command.UrlIot,
                    command.UrlPhoto,
                    command.Location,
                    command.HearRate,
                    (long)command.Temperature,
                    0 
                );

                await _animalRepository.AddAsync(animal);
                await _unitOfWork.CompleteAsync();

                if (animal.Temperature > PermittedTemperatureLevel)
                {
                    await _notificationCommandService.CreateNotificationAsync(
                        "High Temperature Alert",
                        animal.Id,
                        $"Animal {animal.Name} has a high temperature of {animal.Temperature}°C.");
                }

                return animal;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private ESpecie ConvertStringToEnum(string specie)
        {
            if (Enum.TryParse<ESpecie>(specie, true, out var eSpecie))
            {
                return eSpecie;
            }
            else
            {
                throw new ArgumentException($"`{specie}` is not a valid specie`");
            }
        }
    }
}