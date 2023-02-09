using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface ICompteRepository
    {
        Task<IEnumerable<Compte>?> GetAllAsync();
        void Add(Compte compte);
        void Delete(int id);
        Task<Compte?> FindByIdAsync(int? id);
    }
}