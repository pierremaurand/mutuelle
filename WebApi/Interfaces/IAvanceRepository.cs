using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IAvanceRepository
    {
        Task<IEnumerable<Avance>?> GetAllAsync();
        Task<IEnumerable<Avance>?> GetAllByMembreAsync(int membreId);
        void Add(Avance avance);
        void Delete(int id);
        Task<Avance?> FindByIdAsync(int id);
    }
}