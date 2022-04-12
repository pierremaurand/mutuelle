namespace WebApi.Interfaces
{
    public interface IUnitOfWork
    {
         IAgenceRepository AgenceRepository {get; }
         IServiceRepository ServiceRepository {get; }
         ISexeRepository SexeRepository {get; }
         IMembreRepository MembreRepository {get; }
         IParametreRepository ParametreRepository {get; }
         IUserRepository UserRepository {get; }
         Task<bool> SaveAsync();
    }
}