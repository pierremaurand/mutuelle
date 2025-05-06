using System.Threading.Tasks;

namespace mefApi.Interfaces
{
    public interface IUnitOfWork
    {
        IPosteRepository PosteRepository { get; }
        IAgenceRepository AgenceRepository { get; }
        IMembreRepository MembreRepository { get; }
        ICompteComptableRepository CompteComptableRepository { get; }
        IGabaritRepository GabaritRepository { get; }
        IOperationRepository OperationRepository { get; }
        ICompteRepository CompteRepository { get; }
        ICotisationRepository CotisationRepository { get; }
        IAvanceRepository AvanceRepository { get; }
        IDeboursementRepository DeboursementRepository { get; }
        ICreditRepository CreditRepository { get; }
        IEcheanceRepository EcheanceRepository { get; }
        IUtilisateurRepository UtilisateurRepository { get; }
        IMouvementRepository MouvementRepository { get; }
        
        
        Task<bool> SaveAsync();
    }
}