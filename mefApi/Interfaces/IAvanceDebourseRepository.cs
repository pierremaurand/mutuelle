using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IAvanceDebourseRepository
    {
        Task<IEnumerable<AvanceDebourse>?> GetAllAsync();
        void Add(AvanceDebourse avance);
        void Delete(int id);
        Task<AvanceDebourse?> FindByIdAsync(int id);
    }
}