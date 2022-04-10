using WebApi.Interfaces;

namespace hspaApi2.Interfaces
{
    public interface IUnitOfWork
    {
         IAgenceRepository AgenceRepository {get; }
         IUserRepository UserRepository {get; }
         Task<bool> SaveAsync();
    }
}