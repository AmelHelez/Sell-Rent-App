using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Dtos;
using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /*private readonly ICityRepository repo;


public CityController(ICityRepository repo)
{
this.repo = repo;
}*/

        public CityController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        //GET api/city
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            // return new string[] { "Bugojno", "Sarajevo", "Konjic", "Kljuc" };
            var cities = await uow.CityRepository.GetCitiesAsync();

            /*var citiesDto = from c in cities
                            select new CityDto()
                            {
                                ID = c.ID,
                                Name = c.Name
                            };
            */
            var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities);
            return Ok(citiesDto);
        }


        //POST api/city/add?cityName=Kupres
        //POST api/city/add/Maglaj
        [HttpPost("add")]
        [HttpPost("post")]
        [HttpPost("add/{cityName}")]
        // public async Task<IActionResult> AddCity(string cityName)

        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            // City city = new City();
            //city.Name = cityName;
            /*var city = new City
            {
                Name = cityDto.Name,
                LastUpdatedBy = 1,
                LastUpdatedOn = DateTime.Now
            };*/
            var city = mapper.Map<City>(cityDto);
            city.LastUpdatedOn = DateTime.Now;

            uow.CityRepository.AddCity(city);
            await uow.SaveAsync();
            return StatusCode(201); //test
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityDto cityDto)
        {
         
                if (id != cityDto.ID) return BadRequest("Update not allowed.");

                var cityFromDb = await uow.CityRepository.FindCity(id);
                if (cityFromDb == null)
                {
                    return BadRequest("Update not allowed.");
                }
                cityFromDb.LastUpdatedBy = 1;
                cityFromDb.LastUpdatedOn = DateTime.Now;
                mapper.Map(cityDto, cityFromDb); //source i destination
                await uow.SaveAsync();
                return StatusCode(200);


        }

        [HttpPut("updateCityName/{id}")]
        public async Task<IActionResult> UpdateCityName(int id, CityDto cityDto)
        {
            if (id != cityDto.ID) return BadRequest("Update not allowed.");

            var cityFromDb = await uow.CityRepository.FindCity(id);
            if (cityFromDb == null)
            {
                return BadRequest("Update not allowed.");
            }

            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(cityDto, cityFromDb); //source i destination
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch)
        {
            var cityFromDb = await uow.CityRepository.FindCity(id);
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;
            cityToPatch.ApplyTo(cityFromDb, ModelState);
            await uow.SaveAsync();
            return StatusCode(200);
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
