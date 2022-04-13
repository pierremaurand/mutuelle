using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ICotisationRepository
    {
        Task<IEnumerable<Cotisation>?> GetAllAsync();
        void Add(Cotisation cotisation);
        void Delete(int id);
        Task<Cotisation?> FindByIdAsync(int id);
    }
}