namespace WebApi.Interfaces
{
    public interface IUnitOfWork
    {
        IAgenceRepository AgenceRepository { get; }
        IServiceRepository ServiceRepository { get; }
        ISexeRepository SexeRepository { get; }
        IMembreRepository MembreRepository { get; }
        IParametreRepository ParametreRepository { get; }
        IAdhesionRepository AdhesionRepository { get; }
        IAvanceRepository AvanceRepository { get; }
        ICompteRepository CompteRepository { get; }
        ICreditRepository CreditRepository { get; }
        IPeriodeRepository PeriodeRepository { get; }
        IGabarieRepository GabarieRepository { get; }
        ICotisationRepository CotisationRepository { get; }
        IUserRepository UserRepository { get; }
        Task<bool> SaveAsync();
    }
}