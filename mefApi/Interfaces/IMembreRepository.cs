using System.Collections.Generic;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IMembreRepository
    {
        Task<IEnumerable<Membre>?> GetAllAsync();
        Task<IEnumerable<Membre>?> GetByEtatAsync(bool estActif);
        void Add(Membre membre);
        void Delete(int id);
        Task<Membre?> FindByIdAsync(int? id);
    }
}