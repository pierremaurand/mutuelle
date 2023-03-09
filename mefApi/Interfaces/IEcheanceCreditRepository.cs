using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IEcheanceCreditRepository
    {
        Task<IEnumerable<EcheanceCredit>?> GetAllByCreditAsync(int creditId);
        Task<IEnumerable<EcheanceCredit>?> GetAllAsync();
        void Add(EcheanceCredit echeancecredit);
        void Delete(int id);
        Task<EcheanceCredit?> FindByIdAsync(int id);
    }
}