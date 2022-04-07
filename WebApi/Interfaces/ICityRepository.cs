using hspaApi2.Models;

namespace hspaApi2.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllAsync();
        void Add(City city);
        void Delete(int cityId);
        Task<City> FindByIdAsync(int id);
        City FindById(int id);
    }
}