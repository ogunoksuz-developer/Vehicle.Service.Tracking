using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Web.Data.Entities
{
    public class ServiceEntry
    {
        [Key]
        public int ServiceId { get; set; }
        public string LicensePlate { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public int Mileage { get; set; }
        public int? ModelYear { get; set; }
        public DateTime ServiceArrivalDate { get; set; }
        public bool? Warranty { get; set; }
        public int CityId { get; set; }
        public string ServiceNote { get; set; }
    }
}
