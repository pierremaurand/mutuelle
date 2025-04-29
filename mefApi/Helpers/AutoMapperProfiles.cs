using AutoMapper;
using mefapi.Enums;
using mefApi.Dtos;
using mefApi.Models;

namespace mefApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Utilisateur, UtilisateurDto>().ReverseMap();
            CreateMap<Membre, MembreDto>().ReverseMap();
            CreateMap<Membre, CompteDto>().ReverseMap();
            CreateMap<Membre, CompteInfosDto>().ReverseMap();
            CreateMap<Poste, PosteDto>().ReverseMap();
            CreateMap<CompteComptable, CompteComptableDto>().ReverseMap();
            CreateMap<Gabarit, GabaritDto>().ReverseMap();
            CreateMap<Operation, OperationDto>().ReverseMap();
            CreateMap<Compte, CompteDto>().ReverseMap();
            CreateMap<Mouvement, MouvementDto>().ReverseMap();
            CreateMap<Cotisation, CotisationDto>().ReverseMap();
            CreateMap<LieuAffectation, LieuAffectationDto>().ReverseMap();
            CreateMap<Avance, AvanceDto>().ReverseMap();
            CreateMap<Deboursement, DeboursementDto>().ReverseMap();
            CreateMap<Echeance, EcheanceDto>().ReverseMap();
            CreateMap<Credit, CreditDto>().ReverseMap();
        }
    }
}