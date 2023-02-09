using mefApi.Data.Repo;
using mefApi.Interfaces;

namespace mefApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;
        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }


        public ISexeRepository SexeRepository =>
            new SexeRepository(dc);

        public IMembreRepository MembreRepository =>
            new MembreRepository(dc);

        public IPosteRepository PosteRepository =>
            new PosteRepository(dc);

        public ICompteComptableRepository CompteComptableRepository =>
            new CompteComptableRepository(dc);

        public IGabaritRepository GabaritRepository =>
            new GabaritRepository(dc);
        
        public ICompteRepository CompteRepository =>
            new CompteRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}