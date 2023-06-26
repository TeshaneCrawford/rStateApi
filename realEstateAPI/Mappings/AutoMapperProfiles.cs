using AutoMapper;
using realEstateAPI.Models.Domain;
using realEstateAPI.Models.DTO;

namespace realEstateAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Property, PropertyDto>().ReverseMap();
            CreateMap<AddPropertyRequestDto, Property>().ReverseMap();
            CreateMap<UpdatePropertyRequestDto, Property>().ReverseMap();
        }
    }
}
