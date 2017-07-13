using BirdAPI.Persistence.Respositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirdAPI.Models
{
    public class BirdBreed : IBirdBreed
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String ScientificName { get; set; }
        public String Range { get; set; }
        public BirdObserver BirdObserver { get; set; }
    }
}