using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IAgenceRepository
    {
        Task<IEnumerable<Agence>?> GetAllAsync();
        void Add(Agence agence);
        void Delete(int id);
        Task<Agence?> FindByIdAsync(int id);
    }
}