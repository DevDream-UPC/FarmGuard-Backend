namespace FarmGuard_Backend.Animals.Domain.Model.Commands
{
    public class CreateAnimalCommand
    {
        public string Name { get; set; }
        public string Specie { get; set; }
        public string UrlIot { get; set; }
        public string UrlPhoto { get; set; }
        public string Location { get; set; }
        public int HearRate { get; set; }
        public double Temperature { get; set; }
    }
}