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


        public ISexeRepository SexeRepository =>
            new SexeRepository(dc);
        
        public IPosteRepository PosteRepository =>
            new PosteRepository(dc);

        public ILieuAffectationRepository LieuAffectationRepository =>
            new LieuAffectationRepository(dc);

        public IMembreRepository MembreRepository =>
            new MembreRepository(dc);

        public ICompteComptableRepository CompteComptableRepository =>
            new CompteComptableRepository(dc);

        public IGabaritRepository GabaritRepository =>
            new GabaritRepository(dc);

        public IOperationRepository OperationRepository =>
            new OperationRepository(dc);

        public IMvtCompteRepository MvtCompteRepository =>
            new MvtCompteRepository(dc);
        
        public IAvanceRepository AvanceRepository =>
            new AvanceRepository(dc);

        public IAvanceDebourseRepository AvanceDebourseRepository =>
            new AvanceDebourseRepository(dc);

        public IMvtAvanceDebourseRepository MvtAvanceDebourseRepository =>
            new MvtAvanceDebourseRepository(dc);
        
        public ICotisationRepository CotisationRepository =>
            new CotisationRepository(dc);

        public ICreditRepository CreditRepository =>
            new CreditRepository(dc);

        public ICreditDebourseRepository CreditDebourseRepository =>
            new CreditDebourseRepository(dc);

        public IMvtCreditDebourseRepository MvtCreditDebourseRepository =>
            new MvtCreditDebourseRepository(dc);

        public IDetailEcritureComptableRepository DetailEcritureComptableRepository =>
            new DetailEcritureComptableRepository(dc);

        public IEcritureComptableRepository EcritureComptableRepository =>
            new EcritureComptableRepository(dc);

        public IEcheanceCreditRepository EcheanceCreditRepository =>
            new EcheanceCreditRepository(dc);

        public IMvtEcheanceCreditRepository MvtEcheanceCreditRepository =>
            new MvtEcheanceCreditRepository(dc);

        public IEcheanceAvanceRepository EcheanceAvanceRepository =>
            new EcheanceAvanceRepository(dc);

        public IMvtEcheanceAvanceRepository MvtEcheanceAvanceRepository =>
            new MvtEcheanceAvanceRepository(dc);

        public IMoisRepository MoisRepository =>
            new MoisRepository(dc);

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