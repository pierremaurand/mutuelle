using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IDemandeCreditRepository
    {
        Task<IEnumerable<DemandeCredit>?> GetAllAsync();
        void Add(DemandeCredit demandeCredit);
        void Delete(int id);
        Task<DemandeCredit?> FindByIdAsync(int id);
    }
}