using FarmGuard_Backend.Animals.Domain.Model.ValueObjects;

namespace FarmGuard_Backend.Animals.Domain.Model.Commands
{
    public class CreateRecommendationCommand
    {
        public string Content { get; set; }
        public ESpecie Species { get; set; }
        public int InventoryId { get; set; }
    }
}