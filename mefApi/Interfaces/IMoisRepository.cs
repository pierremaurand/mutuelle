using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IMoisRepository
    {
        Task<IEnumerable<Mois>?> GetAllAsync();
    }
}