using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        void AddCity(City city);
        void DeleteCity(int cityId);

    }
}
