using AutoMapper;
using hspaApi2.Models;
using WebApi.Dtos;
using WebApi.Models;

namespace hspaApi2.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Agence, AgenceDto>().ReverseMap();
            
            CreateMap<Service, ServiceDto>().ReverseMap();

            CreateMap<Sexe, SexeDto>().ReverseMap();
            
            CreateMap<Membre, MembreDetailDto>().ReverseMap();

            CreateMap<Membre, MembreListDto>()
                .ForMember(d => d.Agence, opt => opt.MapFrom(src => src.Agence.Nom))
                .ForMember(d => d.Service, opt => opt.MapFrom(src => src.Service.Nom))
                .ForMember(d => d.Sexe, opt => opt.MapFrom(src => src.Sexe.Nom));
        }
    }
}