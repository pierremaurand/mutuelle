using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IAdhesionRepository
    {
        Task<IEnumerable<Adhesion>?> GetAllAsync();
        void Add(Adhesion adhesion);
        void Delete(int id);
        Task<Adhesion?> FindByIdAsync(int id);
    }
}