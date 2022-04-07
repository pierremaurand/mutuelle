using hspaApi2.Interfaces;
using hspaApi2.Models;
using Microsoft.EntityFrameworkCore;

namespace hspaApi2.Data.Repo
{
    public class PropertyRepository : IPropertyRepository
    {
        public readonly DataContext dc;
        public PropertyRepository(DataContext dc) 
        {
            this.dc = dc;  
        }

        public void Add(Property property)
        {
            if(dc.Properties is not null && property is not null) {
                dc.Properties.Add(property);
            }
        }

        public void Delete(int id)
        {
            if(dc.Properties is not null) {
                var property = dc.Properties.Find(id);
                if(property is not null) {
                    dc.Properties.Remove(property);
                }
            }
        }

        public async Task<IEnumerable<Property>> GetAllAsync(int sellRent)
        {
            if(dc.Properties is not null) {
                var properties = await dc.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.FurnishingType)
                .Include(p => p.City)
                .Include(p => p.User)
                .Include(p  => p.Photos)
                .Where(p => p.SellRent == sellRent)
                .ToListAsync();
                if(properties is not null) {
                    return properties;
                }
            }
            return new Property[]{};
        }

        public async Task<Property> FindByIdAsync(int id)
        {
            if(dc.Properties is not null) {
                var properties = await dc.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.FurnishingType)
                .Include(p => p.City)
                .Include(p => p.User)
                .Include(p  => p.Photos)
                .Where(p => p.Id == id)
                .FirstAsync();
                if(properties is not null) {
                    return properties;
                }
            }
            return new Property(){};
        }

        public Property FindById(int id)
        {
            if(dc.Properties is not null) {
                var properties = dc.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.FurnishingType)
                .Include(p => p.City)
                .Include(p => p.User)
                .Include(p  => p.Photos)
                .Where(p => p.Id == id)
                .First();
                if(properties is not null) {
                    return properties;
                }
            }
            return new Property(){};
        }
    }
}