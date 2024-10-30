using FarmGuard_Backend.Animals.Domain.Model.ValueObjects;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;

namespace FarmGuard_Backend.Animals.Domain.Model.Aggregates;

public class Animal
{
    public Animal(){}
    public Animal(
        string name, 
        string specie, 
        string urlIot, 
        string urlPhoto, 
        string location, 
        long hearRate,
        long temperature)
    {
        Name = name;
        SerialNumber = new SerialNumberAnimal();
        
        //Funcion para convertir en Enum
        Specie = ConvertStringToEnum(specie);

        UrlIot = urlIot;
        UrlPhoto = urlPhoto;

        Vaccines = new List<Vaccine>();
        
        Location = location;
        HearRate = hearRate;
        Temperature = temperature;
    }
    public int Id { get; }
    public SerialNumberAnimal SerialNumber { get; private set; }
    public string Name { get; private set; }
    public ESpecie Specie { get; private set; }
    /*Vacunas*/
    public ICollection<Vaccine> Vaccines { get; private set; }
    public string UrlIot { get; private set; }
    public string UrlPhoto { get; private set; }
    /*Inventario*/
    public string Location { get; private set; }
    public long HearRate { get; private set; }
    public long Temperature { get; private set; }
    
    /*Funciones*/
    public ESpecie ConvertStringToEnum(string specie)
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