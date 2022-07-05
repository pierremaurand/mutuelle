using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IMembreRepository
    {
        Task<IEnumerable<Membre>?> GetAllAsync();
        void Add(Membre membre);
        void Delete(int id);
        Task<Membre?> FindByIdAsync(int id);
    }
}