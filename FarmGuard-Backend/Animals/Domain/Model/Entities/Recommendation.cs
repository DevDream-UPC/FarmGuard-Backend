
using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.ValueObjects;

namespace FarmGuard_Backend.Animals.Domain.Model.Entities
{
    public class Recommendations
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public ESpecie Species { get; set; }
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
    }
}