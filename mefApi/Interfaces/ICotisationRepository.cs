using System.Collections.Generic;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface ICotisationRepository
    {
        Task<IEnumerable<Cotisation>?> GetAllByMembreAsync(int membreId);
        Task<IEnumerable<Cotisation>?> GetAllAsync();
        void Add(Cotisation cotisation);
        void Delete(int id);
        Task<Cotisation?> FindByIdAsync(int id);
    }
}