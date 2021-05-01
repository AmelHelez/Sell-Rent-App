using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        /*private readonly ICityRepository repo;


public CityController(ICityRepository repo)
{
this.repo = repo;
}*/

        public CityController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        //GET api/city
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            // return new string[] { "Bugojno", "Sarajevo", "Konjic", "Kljuc" };
            var cities = await uow.CityRepository.GetCitiesAsync();
            return Ok(cities);
        }

    /*    [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Bugojno";
        }*/


        //POST api/city/add?cityName=Kupres
        //POST api/city/add/Maglaj
        [HttpPost("add")]
        [HttpPost("post")]
        [HttpPost("add/{cityName}")]
        // public async Task<IActionResult> AddCity(string cityName)

        public async Task<IActionResult> AddCity(City city)
        {
           // City city = new City();
            //city.Name = cityName;
            uow.CityRepository.AddCity(city);
            await uow.SaveAsync();
            return StatusCode(201); //test
        }


        [HttpDelete("delete/{cityId}")]
        public async Task<IActionResult> DeleteCity(int cityId)
        {
            // var city = await dc.Cities.FindAsync(cityId);
            // dc.Cities.Remove(city);
            uow.CityRepository.DeleteCity(cityId);
            await uow.SaveAsync();
            return Ok(cityId);

        }
    }
}
