using System;

namespace BirdAPI.Persistence.Respositores
{
    public interface IBirdObserver
    {
        int ID { get; set; }
        int BirdBreedID { get; set; }
        DateTime DateObserved { get; set; }
        string Location { get; set; }
        string Name { get; set; }
        int NumberSpotted { get; set; }
        string ScientificName { get; set; }
    }
}