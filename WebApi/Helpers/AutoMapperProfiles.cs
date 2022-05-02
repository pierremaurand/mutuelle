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

            CreateMap<Membre, MembreDto>().ReverseMap();

            CreateMap<Membre, MembreListDto>()
                .ForMember(d => d.Sexe, opt => opt.MapFrom(src => src.Sexe.Nom))
                .ForMember(d => d.Agence, opt => opt.MapFrom(src => src.Agence.Nom))
                .ForMember(d => d.Service, opt => opt.MapFrom(src => src.Service.Nom));

            CreateMap<Compte, CompteDto>().ReverseMap();

            CreateMap<Cotisation, CotisationDto>().ReverseMap();

            CreateMap<Avance, AvanceDto>().ReverseMap();

            CreateMap<Credit, CreditDto>().ReverseMap();

            CreateMap<EcheanceAvance, EcheanceAvanceDto>().ReverseMap();

            CreateMap<EcheanceCredit, EcheanceCreditDto>().ReverseMap();
        }
    }
}