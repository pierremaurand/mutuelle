using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IMvtEcheanceAvanceRepository
    {
        Task<IEnumerable<MvtEcheanceAvance>?> GetAllAsync();
        void Add(MvtEcheanceAvance echeance);
        void Delete(int id);
        Task<MvtEcheanceAvance?> FindByIdAsync(int? id);
    }
}