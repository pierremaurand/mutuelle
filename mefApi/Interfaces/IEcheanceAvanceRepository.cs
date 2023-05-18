using System.Collections.Generic;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IEcheanceAvanceRepository
    {
        Task<IEnumerable<EcheanceAvance>?> GetAllByAvanceAsync(int avanceId);
        Task<IEnumerable<EcheanceAvance>?> GetAllAsync();
        void Add(EcheanceAvance echeanceavance);
        void Delete(int id);
        Task<EcheanceAvance?> FindByIdAsync(int id);
    }
}