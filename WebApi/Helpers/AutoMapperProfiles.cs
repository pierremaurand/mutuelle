using AutoMapper;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Agence, AgenceDto>().ReverseMap();
            
            CreateMap<Service, ServiceDto>().ReverseMap();

            CreateMap<Sexe, SexeDto>().ReverseMap();

            CreateMap<Parametre, ParametreDto>().ReverseMap();

            CreateMap<Membre, MembreDto>()
                .ForMember(d => d.Agence, opt => opt.MapFrom(src => src.Agence.Nom))
                .ForMember(d => d.Service, opt => opt.MapFrom(src => src.Service.Nom))
                .ForMember(d => d.Sexe, opt => opt.MapFrom(src => src.Sexe.Nom));

            CreateMap<MembreDto, Membre>();

            CreateMap<Compte, CompteDto>().ReverseMap();

            CreateMap<Periode, PeriodeDto>().ReverseMap();

            CreateMap<Cotisation, CotisationDto>().ReverseMap();

            CreateMap<Cotisation, CotisationListDto>()
                .ForMember(c => c.Periode, opt => opt.MapFrom(src => src.Periode.Libelle));

            CreateMap<CotisationDto, Cotisation>();
        }
    }
}