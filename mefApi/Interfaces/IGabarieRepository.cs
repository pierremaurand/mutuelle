using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IGabarieRepository
    {
        Task<IEnumerable<Gabarie>?> GetAllAsync();
        void Add(Gabarie gabarie);
        void Delete(int id);
        Task<Gabarie?> FindByIdAsync(int id);
    }
}