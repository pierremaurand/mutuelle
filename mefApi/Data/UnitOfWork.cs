using System.Threading.Tasks;
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
        
        public IPosteRepository PosteRepository =>
            new PosteRepository(dc);

        public IAgenceRepository AgenceRepository =>
            new AgenceRepository(dc);

        public IMembreRepository MembreRepository =>
            new MembreRepository(dc);

        public ICompteComptableRepository CompteComptableRepository =>
            new CompteComptableRepository(dc);

        public IGabaritRepository GabaritRepository =>
            new GabaritRepository(dc);

        public IOperationRepository OperationRepository =>
            new OperationRepository(dc);

        public ICompteRepository CompteRepository =>
            new CompteRepository(dc);
        
        public IAvanceRepository AvanceRepository =>
            new AvanceRepository(dc);

        public IDeboursementRepository DeboursementRepository =>
            new DeboursementRepository(dc);
        
        public ICotisationRepository CotisationRepository =>
            new CotisationRepository(dc);

        public ICreditRepository CreditRepository =>
            new CreditRepository(dc);

        public IDetailEcritureComptableRepository DetailEcritureComptableRepository =>
            new DetailEcritureComptableRepository(dc);

        public IEcritureComptableRepository EcritureComptableRepository =>
            new EcritureComptableRepository(dc);

        public IEcheanceRepository EcheanceRepository =>
            new EcheanceRepository(dc);


        public IUtilisateurRepository UtilisateurRepository =>
            new UtilisateurRepository(dc);

        public IMouvementRepository MouvementRepository =>
            new MouvementRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}