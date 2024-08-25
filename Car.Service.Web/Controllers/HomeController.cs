using AutoMapper;
using Car.Service.Web.Business.Abstract;
using Car.Service.Web.Data.Entities;
using Car.Service.Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Vehicle.Service.Tracking.Models;
using Vehicle.Service.Tracking.Models.Api;

namespace Car.Service.Web.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class HomeController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IServiceEntryService _serviceEntryService;
        private readonly IMapper _mapper;

        public HomeController(ICityService cityService, IServiceEntryService serviceEntryService, IMapper mapper)
        {
            _cityService = cityService;
            _serviceEntryService = serviceEntryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var serviceEntries = await _serviceEntryService.GetAllServiceEntriesFromStoreProcedureAsync();

            var model = _mapper.Map<IEnumerable<ServiceEntryListModel>>(serviceEntries);

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var model = new ServiceEntryListModel();

            var cities = await _cityService.GetAllCitiesAsync();

            model.Cities = cities.Select(x => new SelectListItem
            {
                Text = x.CityName,
                Value = x.CityId.ToString()
            }).ToList();

            model.ServiceArrivalDate = DateTime.Now;

            return View("CreateOrUpdate", model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var serviceEntry = await _serviceEntryService.GetServiceEntryByIdAsync(id);

            var model = _mapper.Map<ServiceEntryListModel>(serviceEntry);

            var cities = await _cityService.GetAllCitiesAsync();

            model.Cities = cities.Select(x => new SelectListItem
            {
                Text = x.CityName,
                Value = x.CityId.ToString()
            }).ToList();

            return View("CreateOrUpdate", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(ServiceEntryListModel model)
        {
            if (ModelState.IsValid)
            {
                var serviceEntry = _mapper.Map<ServiceEntry>(model);

                if (model.ServiceId == 0)
                {
                    await _serviceEntryService.CreateServiceEntryAsync(serviceEntry);
                }
                else
                {
                    _serviceEntryService.UpdateServiceEntry(serviceEntry);
                }

                return RedirectToAction("Index");
            }

            var cities = await _cityService.GetAllCitiesAsync();

            model.Cities = cities.Select(x => new SelectListItem
            {
                Text = x.CityName,
                Value = x.CityId.ToString()
            }).ToList();

            return View("CreateOrUpdate", model);
        }

    }
}
