using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IMvtCompteRepository
    {
        Task<IEnumerable<MvtCompte>?> GetAllAsync();
        void Add(MvtCompte mvtCompte);
        void Delete(int id);
        Task<MvtCompte?> FindByIdAsync(int id);
    }
}