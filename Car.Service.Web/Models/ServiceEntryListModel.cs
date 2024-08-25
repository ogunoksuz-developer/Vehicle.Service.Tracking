using Car.Service.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.Serialization;

namespace Vehicle.Service.Tracking.Models
{
    public class ServiceEntryListModel
    {
        public ServiceEntryListModel()
        {
            Cities = new List<SelectListItem>();
        }

        public int ServiceId { get; set; }
        public string LicensePlate { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public int Mileage { get; set; }
        public int? ModelYear { get; set; }
        public DateTime ServiceArrivalDate { get; set; }
        public bool Warranty { get; set; }
        public int CityId { get; set; }
        public string ServiceNote { get; set; }

        public IEnumerable<SelectListItem>? Cities { get; set; }


    }
}
