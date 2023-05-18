using System.Collections.Generic;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IMoisRepository
    {
        Task<IEnumerable<Mois>?> GetAllAsync();
    }
}