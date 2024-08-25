using AutoMapper;
using Car.Service.Web.Data.Entities;
using Vehicle.Service.Tracking.Models;
using Vehicle.Service.Tracking.Models.Api;

namespace Vehicle.Service.Tracking.Utilities.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ServiceEntryListModel, ServiceEntry>().ReverseMap();
            CreateMap<ServiceEntry, ServiceEntryListModel>().ReverseMap();
            CreateMap<ServiceEntryResponseModel, ServiceEntry>().ReverseMap();
            CreateMap<ServiceEntry, ServiceEntryResponseModel>().ReverseMap();
        }
    }
}
