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
                .ForMember(d => d.Agence, opt => opt.MapFrom(src => src.Agence))
                .ForMember(d => d.Service, opt => opt.MapFrom(src => src.Service))
                .ForMember(d => d.Cotisations, opt => opt.MapFrom(src => src.Cotisations))
                .ForMember(d => d.Avances, opt => opt.MapFrom(src => src.Avances))
                .ForMember(d => d.Credits, opt => opt.MapFrom(src => src.Credits))
                .ReverseMap();

            CreateMap<Membre, MembreListDto>()
                .ForMember(d => d.Agence, opt => opt.MapFrom(src => src.Agence.Nom));

            CreateMap<Compte, CompteDto>().ReverseMap();

            CreateMap<Cotisation, CotisationListDto>();

            CreateMap<Cotisation, CotisationDto>().ReverseMap();

            CreateMap<Avance, AvanceDto>().ReverseMap();

            CreateMap<Credit, CreditDto>().ReverseMap();

            CreateMap<EcheanceAvance, EcheanceAvanceDto>().ReverseMap();

            CreateMap<EcheanceCredit, EcheanceCreditDto>().ReverseMap();
        }
    }
}