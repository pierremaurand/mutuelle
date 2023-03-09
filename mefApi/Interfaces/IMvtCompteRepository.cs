using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IMvtCompteRepository
    {
        Task<IEnumerable<MvtCompte>?> GetAllByMembreAsync(int membreId);
        Task<IEnumerable<MvtCompte>?> GetAllAsync();
        void Add(MvtCompte mvtcompte);
        void Delete(int id);
        Task<MvtCompte?> FindByIdAsync(int id);
    }
}