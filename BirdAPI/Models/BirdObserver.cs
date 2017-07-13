using BirdAPI.Persistence.Respositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BirdAPI.Models
{
    public class BirdObserver : IBirdObserver
    {
        public int ID { get; set; }
        public int BirdBreedID { get; set; }
        public string Location { get; set; }
        public int NumberSpotted { get; set; }
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public DateTime DateObserved { get; set; }
    }
}