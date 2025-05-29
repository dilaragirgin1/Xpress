using AutoMapper;
using BG.Express.API.Data.Entity;
using BG.Express.API.Model.Request;
using BG.Express.API.Model.Response;

namespace BG.Express.API.Helpers;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, AddressResponse>();
            CreateMap<AddressCreateRequest, Address>();
            CreateMap<AddressUpdateRequest, Address>();
            CreateMap<GeocodeWarning, Address>().ReverseMap();
            CreateMap<GeocodedLocation, Address>().ReverseMap();

        }
    }
