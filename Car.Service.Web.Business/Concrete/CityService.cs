using Car.Service.Web.Business.Abstract;
using Car.Service.Web.Data.Abstract;
using Car.Service.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Web.Business.Concrete
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> _cityRepository;

        public CityService(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await _cityRepository.GetAllAsync();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            return await _cityRepository.GetByIdAsync(id);
        }

        public async Task<City> GetCityByNameAsync(string name)
        {
            var cities = await _cityRepository.SearchAsync(x => x.CityName.ToLower() == name.ToLower()).ToListAsync();
            return cities.FirstOrDefault();
        }

    }
}
