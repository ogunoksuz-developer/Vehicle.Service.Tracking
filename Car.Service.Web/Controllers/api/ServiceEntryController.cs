using AutoMapper;
using Car.Service.Web.Business.Abstract;
using Car.Service.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Service.Tracking.Models;
using Vehicle.Service.Tracking.Models.Api;

namespace Vehicle.Service.Tracking.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceEntryController : Controller
    {
        private readonly IServiceEntryService _serviceEntryService;
        private readonly IMapper _mapper;
        private readonly ICityService _cityService;

        public ServiceEntryController(IServiceEntryService serviceEntryService,IMapper mapper,ICityService cityService)
        {
            _cityService = cityService;
            _serviceEntryService = serviceEntryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetServiceEntry")]
        public async Task<IActionResult> GetServiceEntry()
        {
            var serviceEntries = await _serviceEntryService.GetAllServiceEntriesFromStoreProcedureAsync();

            var model = _mapper.Map<IEnumerable<ServiceEntryResponseModel>>(serviceEntries);

            foreach (var item in model)
            {
                var city = await _cityService.GetCityByIdAsync(item.CityId);
                item.CityName = city.CityName;
            }

            return Ok(model);
        }

        [HttpPost]
        [Route("AddServiceEntry")]
        public async Task<IActionResult> AddServiceEntry(ServiceEntryResponseModel serviceEntryModel)
        {
            if (serviceEntryModel is null)
                return BadRequest();
            
            var serviceEntry = _mapper.Map<ServiceEntry>(serviceEntryModel);

            var city = await _cityService.GetCityByNameAsync(serviceEntryModel.CityName);

            if (city != null)
               serviceEntry.CityId = city.CityId;

            await _serviceEntryService.CreateServiceEntryAsync(serviceEntry);

            return Ok();
        }
    }
}
