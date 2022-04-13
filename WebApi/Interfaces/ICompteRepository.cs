using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ICompteRepository
    {
        Task<IEnumerable<Compte>?> GetAllAsync();
        void Add(Compte compte);
        void Delete(int id);
        Task<Compte?> FindByIdAsync(int id);
    }
}