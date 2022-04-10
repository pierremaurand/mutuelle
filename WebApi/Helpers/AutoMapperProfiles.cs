using AutoMapper;
using hspaApi2.Models;
using WebApi.Dtos;

namespace hspaApi2.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Agence, AgenceDto>().ReverseMap();
        }
    }
}