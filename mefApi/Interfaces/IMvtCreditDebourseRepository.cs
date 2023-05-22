using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IMvtCreditDebourseRepository
    {
        Task<IEnumerable<MvtCreditDebourse>?> GetAllAsync();
        void Add(MvtCreditDebourse mvtCredit);
        void Delete(int id);
        Task<MvtCreditDebourse?> FindByIdAsync(int? id);
    }
}