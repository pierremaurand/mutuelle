using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IMvtAvanceDebourseRepository
    {
        Task<IEnumerable<MvtAvanceDebourse>?> GetAllAsync();
        void Add(MvtAvanceDebourse mvtAvance);
        void Delete(int id);
        Task<MvtAvanceDebourse?> FindByIdAsync(int? id);
    }
}