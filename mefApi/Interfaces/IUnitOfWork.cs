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
        
        
        Task<bool> SaveAsync();
    }
}