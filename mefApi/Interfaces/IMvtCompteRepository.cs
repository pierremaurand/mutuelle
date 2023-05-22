using System.Collections.Generic;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IMvtCompteRepository
    {
        Task<IEnumerable<MvtCompte>?> GetAllAsync();
        void Add(MvtCompte mvtcompte);
        void Delete(int id);
        Task<MvtCompte?> FindByIdAsync(int id);
    }
}