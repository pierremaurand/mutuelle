using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ICreditRepository
    {
        Task<IEnumerable<Credit>?> GetAllAsync();
        Task<IEnumerable<Credit>?> GetAllByMembreAsync(int id);
        void Add(Credit credit);
        void Delete(int id);
        Task<Credit?> FindByIdAsync(int id);
    }
}