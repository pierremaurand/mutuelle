using System.Collections.Generic;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IEcheanceAvanceRepository
    {
        Task<IEnumerable<EcheanceAvance>?> GetAllAsync();
        void Add(EcheanceAvance echeanceavance);
        void Delete(int id);
        Task<ICollection<EcheanceAvance>?> FindByIdAsync(int id);
    }
}