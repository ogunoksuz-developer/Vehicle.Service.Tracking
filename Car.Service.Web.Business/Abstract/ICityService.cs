using Car.Service.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Web.Business.Abstract
{
    public interface ICityService
    {
        Task<City> GetCityByIdAsync(int id);

        Task<IEnumerable<City>> GetAllCitiesAsync();

        Task<City> GetCityByNameAsync(string name);

    }
}
