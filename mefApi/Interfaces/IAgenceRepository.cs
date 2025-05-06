using System.Collections.Generic;
using System.Threading.Tasks;
using mefApi.Dtos;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IAgenceRepository
    {
        Task<IEnumerable<Agence>?> GetAllAsync();
        Task<bool> AgenceExists(string nom);
        void Add(Agence agence);
        void Delete(int id);
        Task<Agence?> FindByIdAsync(int id);
        Task<Agence?> FindByNomAsync(string nom);
    }
}