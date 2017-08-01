using AutoMapper;
using BirdAPI.Dto;
using BirdAPI.Models;
using BirdAPI.Persistence.Respositores;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BirdAPI.Controllers
{
    public class BirdController : ApiController
    {

        private readonly IApplicationDbContext _context;

        private readonly IBirdObserver __birdObserver;
        private readonly IBirdBreed _birdBreed;

        public BirdController(IBirdObserver birdObserver, IBirdBreed birdBreed, IApplicationDbContext context)
        {
            __birdObserver = birdObserver;
            _birdBreed = birdBreed;
            _context = context;
               
        }
        public int ConvertToInt(string num)
        {
            int numOut = 1;
            int.TryParse(num, out numOut);
            return numOut;
        }

        // GET api/values
        public IEnumerable<BirdObserverDto> Put(CoordinatesDto coordinates)
        {
            
            string json = "";
            try
            {
                using (WebClient wc = new WebClient())
                {
                    string url = String.Format("http://ebird.org/ws1.1/data/obs/geo/recent?lng={0}&lat={1}&fmt=json",
                        coordinates.longitude.ToString(), coordinates.latitude.ToString());
                    json = wc.DownloadString(url);
                    JArray birdObserverArray = JArray.Parse(json);
                    IList<BirdObserverDto> birdObserverDto = new List<BirdObserverDto>();
                    try {
                    IList<BirdObserver> birdObservers = birdObserverArray.Select(bo => new BirdObserver
                    {
                        Name = (string)bo["comName"],
                        ScientificName = (string)bo["sciName"],
                        Location = (string)bo["locName"],                     
                        NumberSpotted = ConvertToInt((string)bo["howMany"]),
                        DateObserved = (DateTime)bo["obsDt"]
                    }).ToList();
                    
                    foreach (BirdObserver bo in birdObservers)
                    {
                        var boDto = Mapper.Map<BirdObserver, BirdObserverDto>(bo);
                        birdObserverDto.Add(boDto);
                        _context.BirdObservers.Add(bo);
                    }
                    _context.SaveChanges(); //now do a save to the Database
                    }
                    catch(Exception e)
                    {
                        string msg = e.InnerException.Message;
                    }
                    return birdObserverDto;
                }
            }
            catch(Exception e)
            {
                string taz = e.InnerException.ToString();
            }
            return null;
            
        }

    }

}
