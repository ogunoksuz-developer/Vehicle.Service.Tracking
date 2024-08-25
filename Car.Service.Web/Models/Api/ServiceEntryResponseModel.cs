using AutoMapper.Configuration.Annotations;
using System.Text.Json.Serialization;

namespace Vehicle.Service.Tracking.Models.Api
{
    public class ServiceEntryResponseModel
    {
        public string? LicensePlate { get; set; }
        public string? BrandName { get; set; }
        public string? ModelName { get; set; }
        public int Mileage { get; set; }
        public int? ModelYear { get; set; }
        public DateTime ServiceArrivalDate { get; set; }
        public bool Warranty { get; set; }
        public string? CityName { get; set; }

        [JsonIgnore]
        public int CityId { get; set; }

        public string? ServiceNote { get; set; }
    }
}
