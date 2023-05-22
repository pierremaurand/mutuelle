using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface ICreditDebourseRepository
    {
        Task<IEnumerable<CreditDebourse>?> GetAllAsync();
        void Add(CreditDebourse credit);
        void Delete(int id);
        Task<CreditDebourse?> FindByIdAsync(int id);
    }
}