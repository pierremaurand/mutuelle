using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IPeriodeRepository
    {
         Task<IEnumerable<Periode>?> GetAllAsync();
        void Add(Periode periode);
        void Delete(int id);
        Task<Periode?> FindByIdAsync(int id);
    }
}