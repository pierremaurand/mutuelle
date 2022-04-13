using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IAvanceRepository
    {
        Task<IEnumerable<Avance>?> GetAllAsync();
        void Add(Avance avance);
        void Delete(int id);
        Task<Avance?> FindByIdAsync(int id);
    }
}