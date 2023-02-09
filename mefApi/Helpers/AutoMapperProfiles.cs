using AutoMapper;
using mefApi.Dtos;
using mefApi.Models;

namespace mefApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<Sexe, SexeDto>().ReverseMap();
            CreateMap<Sexe, SexeListDto>().ReverseMap();
            CreateMap<NewSexeDto, Sexe>().ReverseMap();

            CreateMap<Membre, MembreDetailsDto>()
            .ForMember(d => d.SexeNom, opt => opt.MapFrom(src => src.Sexe.Nom))
            .ForMember(d => d.PosteLibelle, opt => opt.MapFrom(src => src.Poste.Libelle)).ReverseMap();
            CreateMap<Membre, MembreDto>().ReverseMap();
            CreateMap<NewMembreDto, Membre>().ReverseMap();

            CreateMap<Poste, PosteDto>().ReverseMap();
            CreateMap<Poste, PosteListDto>().ReverseMap();
            CreateMap<NewPosteDto, Poste>().ReverseMap();

            CreateMap<CompteComptable, CompteComptableDto>().ReverseMap();
            CreateMap<NewCompteComptableDto, CompteComptable>().ReverseMap();

            CreateMap<Gabarit, GabaritDto>().ReverseMap();
            CreateMap<Gabarit, GabaritListDto>().ReverseMap();
            CreateMap<NewGabaritDto, Gabarit>().ReverseMap();
            
            CreateMap<Operation, OperationDto>().ReverseMap();
            CreateMap<NewOperationDto, Operation>().ReverseMap();

            CreateMap<Compte, CompteMembreDto>().ReverseMap();
        }
    }
}