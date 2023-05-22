using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IMvtEcheanceCreditRepository
    {
        Task<IEnumerable<MvtEcheanceCredit>?> GetAllAsync();
        void Add(MvtEcheanceCredit echeance);
        void Delete(int id);
        Task<MvtEcheanceCredit?> FindByIdAsync(int? id);
    }
}