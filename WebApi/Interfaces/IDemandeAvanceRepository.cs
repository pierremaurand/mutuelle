using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IDemandeAvanceRepository
    {
        Task<IEnumerable<DemandeAvance>?> GetAllAsync();
        void Add(DemandeAvance demandeAvance);
        void Delete(int id);
        Task<DemandeAvance?> FindByIdAsync(int id);
    }
}