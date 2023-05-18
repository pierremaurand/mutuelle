using AutoMapper;
using mefApi.Dtos;
using mefApi.Models;

namespace mefApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<Utilisateur, UtilisateurDto>().ReverseMap();

            CreateMap<Sexe, SexeDto>().ReverseMap();

            CreateMap<Membre, MembreDto>().ReverseMap();
            CreateMap<Membre, MembreListDto>()
            .ForMember(d => d.Sexe, opt => opt.MapFrom(src => src.Sexe.Nom))
            .ForMember(d => d.Poste, opt => opt.MapFrom(src => src.Poste.Libelle))
            .ForMember(d => d.Lieu, opt => opt.MapFrom(src => src.LieuAffectation.Lieu));
            
            CreateMap<Poste, PosteDto>().ReverseMap();

            CreateMap<Mois, MoisDto>().ReverseMap();

            CreateMap<CompteComptable, CompteComptableDto>().ReverseMap();

            CreateMap<Gabarit, GabaritDto>().ReverseMap();
            
            CreateMap<Operation, OperationDto>().ReverseMap();

            CreateMap<MvtCompte, MvtCompteDto>().ReverseMap();

            CreateMap<Cotisation, CotisationDto>().ReverseMap();
            
            CreateMap<LieuAffectation, LieuAffectationDto>().ReverseMap();
            
            CreateMap<Avance, AvanceDto>().ReverseMap();
            CreateMap<EcheanceAvance, EcheanceAvanceDto>().ReverseMap();

            CreateMap<Credit, CreditDto>().ReverseMap();
            CreateMap<EcheanceCredit, EcheanceCreditDto>().ReverseMap();
        }
    }
}