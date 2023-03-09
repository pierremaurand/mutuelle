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
        IMvtCompteRepository MvtCompteRepository { get; }
        ICotisationRepository CotisationRepository { get; }
        IMoisRepository MoisRepository { get; }
        IAvanceRepository AvanceRepository { get; }
        ICreditRepository CreditRepository { get; }
        IEcheanceAvanceRepository EcheanceAvanceRepository { get; }
        IEcheanceCreditRepository EcheanceCreditRepository { get; }
        
        
        Task<bool> SaveAsync();
    }
}