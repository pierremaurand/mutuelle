using hspaApi2.Models;

namespace hspaApi2.Interfaces
{
    public interface IFurnishingTypeRepository
    {
        Task<IEnumerable<FurnishingType>> GetAllAsync();
        void Add(FurnishingType furnishingType);
        void Delete(int id);
        Task<FurnishingType> FindByIdAsync(int id);
        FurnishingType FindById(int id);
    }
}