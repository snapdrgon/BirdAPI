using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirdAPI.Dto
{
    public class BirdObserverDto
    {
        public string Location { get; set; }
        public int NumberSpotted { get; set; }
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public DateTime DateObserved { get; set; }
    }
}