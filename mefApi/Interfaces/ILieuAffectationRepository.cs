using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface ILieuAffectationRepository
    {
        Task<IEnumerable<LieuAffectation>?> GetAllAsync();
        void Add(LieuAffectation lieuaffectation);
        void Delete(int id);
        Task<LieuAffectation?> FindByIdAsync(int id);
    }
}