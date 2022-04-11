using WebApi.Interfaces;

namespace hspaApi2.Interfaces
{
    public interface IUnitOfWork
    {
         IAgenceRepository AgenceRepository {get; }
         IServiceRepository ServiceRepository {get; }
         ISexeRepository SexeRepository {get; }
         IMembreRepository MembreRepository {get; }
         IUserRepository UserRepository {get; }
         Task<bool> SaveAsync();
    }
}