using System.Threading.Tasks;

namespace mefApi.Interfaces
{
    public interface IUnitOfWork
    {
        ISexeRepository SexeRepository { get; }
        IPosteRepository PosteRepository { get; }
        ILieuAffectationRepository LieuAffectationRepository { get; }
        IMembreRepository MembreRepository { get; }
        ICompteComptableRepository CompteComptableRepository { get; }
        IGabaritRepository GabaritRepository { get; }
        IOperationRepository OperationRepository { get; }
        ICompteRepository CompteRepository { get; }
        IMvtCompteRepository MvtCompteRepository { get; }
        ICotisationRepository CotisationRepository { get; }
        IMvtCotisationRepository MvtCotisationRepository { get; }
        IMoisRepository MoisRepository { get; }
        IAvanceRepository AvanceRepository { get; }
        IAvanceDebourseRepository AvanceDebourseRepository { get; }
        IMvtAvanceDebourseRepository MvtAvanceDebourseRepository { get; }
        ICreditRepository CreditRepository { get; }
        ICreditDebourseRepository CreditDebourseRepository { get; }
        IMvtCreditDebourseRepository MvtCreditDebourseRepository { get; }
        IEcheanceAvanceRepository EcheanceAvanceRepository { get; }
        IMvtEcheanceAvanceRepository MvtEcheanceAvanceRepository { get; }
        IEcheanceCreditRepository EcheanceCreditRepository { get; }
        IMvtEcheanceCreditRepository MvtEcheanceCreditRepository { get; }
        IUtilisateurRepository UtilisateurRepository { get; }
        IMouvementRepository MouvementRepository { get; }
        
        
        Task<bool> SaveAsync();
    }
}