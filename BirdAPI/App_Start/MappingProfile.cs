using AutoMapper;
using BirdAPI.Dto;
using BirdAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirdAPI.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<BirdBreed, BirdBreedDto>();
            Mapper.CreateMap<BirdObserver, BirdObserverDto>();
        }
    }
}