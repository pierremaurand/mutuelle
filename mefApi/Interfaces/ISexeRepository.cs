using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ISexeRepository
    {
        Task<IEnumerable<Sexe>?> GetAllAsync();
        void Add(Sexe sexe);
        void Delete(int id);
        Task<Sexe?> FindByIdAsync(int id);
    }
}