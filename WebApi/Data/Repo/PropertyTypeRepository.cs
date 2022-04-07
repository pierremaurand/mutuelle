using hspaApi2.Interfaces;
using hspaApi2.Models;
using Microsoft.EntityFrameworkCore;

namespace hspaApi2.Data.Repo
{
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        public readonly DataContext dc;
        public PropertyTypeRepository(DataContext dc) 
        {
            this.dc = dc;  
        }
        public async Task<IEnumerable<PropertyType>> GetAllAsync()
        {
            if(dc.PropertyTypes is not null) {
                var propertyTypes = await dc.PropertyTypes.ToListAsync();
                if(propertyTypes is not null) {
                    return propertyTypes;
                }
            }
            return new PropertyType[]{};
        }

        public async Task<PropertyType> FindByIdAsync(int id)
        {

            if(dc.PropertyTypes is not null) {
                var propertyType = await dc.PropertyTypes.FindAsync(id);
                if(propertyType is not null) {
                    return propertyType;
                }
            }
            
            return new PropertyType{};
        }

        public PropertyType FindById(int id)
        {

            if(dc.PropertyTypes is not null) {
                var propertyType = dc.PropertyTypes.Find(id);
                if(propertyType is not null) {
                    return propertyType;
                }
            }
            
            return new PropertyType{};
        }

        public void Add(PropertyType propertyType)
        {
            if(dc.PropertyTypes is not null && propertyType is not null) {
                dc.PropertyTypes.Add(propertyType);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}