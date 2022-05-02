using WebApi.Data.Repo;
using WebApi.Interfaces;

namespace WebApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;
        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }
        public IAgenceRepository AgenceRepository =>
            new AgenceRepository(dc);

        public IUserRepository UserRepository =>
            new UserRepository(dc);

        public IServiceRepository ServiceRepository =>
            new ServiceRepository(dc);

        public ISexeRepository SexeRepository =>
            new SexeRepository(dc);

        public IMembreRepository MembreRepository =>
            new MembreRepository(dc);

        public IParametreRepository ParametreRepository =>
            new ParametreRepository(dc);

        public IAdhesionRepository AdhesionRepository =>
            new AdhesionRepository(dc);

        public IAvanceRepository AvanceRepository =>
            new AvanceRepository(dc);

        public ICompteRepository CompteRepository =>
            new CompteRepository(dc);

        public ICreditRepository CreditRepository =>
            new CreditRepository(dc);

        public IGabarieRepository GabarieRepository =>
            new GabarieRepository(dc);

        public ICotisationRepository CotisationRepository =>
            new CotisationRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}