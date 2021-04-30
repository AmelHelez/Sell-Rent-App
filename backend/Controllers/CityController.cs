using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Bugojno", "Sarajevo", "Konjic", "Kljuc" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Bugojno";
        }
    }
}
