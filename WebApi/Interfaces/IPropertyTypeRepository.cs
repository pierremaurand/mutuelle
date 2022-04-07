using hspaApi2.Models;

namespace hspaApi2.Interfaces
{
    public interface IPropertyTypeRepository
    {
        Task<IEnumerable<PropertyType>> GetAllAsync();
        void Add(PropertyType propertyType);
        void Delete(int id);
        Task<PropertyType> FindByIdAsync(int id);
        PropertyType FindById(int id);
    }
}