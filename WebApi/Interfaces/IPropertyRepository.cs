using hspaApi2.Models;

namespace hspaApi2.Interfaces
{
    public interface IPropertyRepository
    {
         Task<IEnumerable<Property>> GetAllAsync(int sellRent);
         Task<Property> FindByIdAsync(int id);
         Property FindById(int id);
         void Add(Property property);
         void Delete(int id);
    }
}