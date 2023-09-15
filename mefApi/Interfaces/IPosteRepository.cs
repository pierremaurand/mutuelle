using System.Collections.Generic;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IPosteRepository
    {
        Task<IEnumerable<Poste>?> GetAllAsync();
        void Add(Poste poste);
        void Delete(int id);
        Task<Poste?> FindByIdAsync(int id);
    }
}