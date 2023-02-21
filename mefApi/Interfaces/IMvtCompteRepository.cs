using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IMvtCompteRepository
    {
        Task<IEnumerable<MvtCompte>?> GetAllAsync();
        Task<IEnumerable<MvtCompte>?> GetByCompteAsync(int compteId);
        void Add(MvtCompte mvtcompte);
        void Delete(int id);
        Task<MvtCompte?> FindByIdAsync(int id);
    }
}