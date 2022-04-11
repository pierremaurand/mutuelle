using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>?> GetAllAsync();
        void Add(Service service);
        void Delete(int id);
        Task<Service?> FindByIdAsync(int id);
    }
}