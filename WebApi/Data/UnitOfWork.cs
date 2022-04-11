using hspaApi2.Data.Repo;
using hspaApi2.Interfaces;
using WebApi.Data.Repo;
using WebApi.Data.Repo;
using WebApi.Interfaces;

namespace hspaApi2.Data 
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

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}