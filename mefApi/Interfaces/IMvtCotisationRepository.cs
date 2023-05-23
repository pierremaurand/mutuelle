using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IMvtCotisationRepository
    {
        Task<IEnumerable<MvtCotisation>?> GetAllAsync();
        void Add(MvtCotisation mvtcotisation);
        void Delete(int id);
        Task<MvtCotisation?> FindByIdAsync(int id);
    }
}