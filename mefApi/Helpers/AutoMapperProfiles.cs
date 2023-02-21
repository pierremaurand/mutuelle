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

            CreateMap<Membre, MembreDto>().ReverseMap();

            CreateMap<Poste, PosteDto>().ReverseMap();

            CreateMap<CompteComptable, CompteComptableDto>().ReverseMap();

            CreateMap<Gabarit, GabaritDto>().ReverseMap();
            
            CreateMap<Operation, OperationDto>().ReverseMap();

            CreateMap<Compte, CompteDto>().ReverseMap();

            CreateMap<MvtCompte, MvtCompteDto>().ReverseMap();
            
            CreateMap<LieuAffectation, LieuAffectationDto>().ReverseMap();
        }
    }
}