using hspaApi2.Interfaces;
using hspaApi2.Models;
using Microsoft.EntityFrameworkCore;

namespace hspaApi2.Data.Repo
{
    public class FurnishingTypeRepository : IFurnishingTypeRepository
    {
        public readonly DataContext dc;
        public FurnishingTypeRepository(DataContext dc) 
        {
            this.dc = dc;  
        }
        public async Task<IEnumerable<FurnishingType>> GetAllAsync()
        {
            if(dc.FurnishingTypes is not null) {
                var furnishingTypes = await dc.FurnishingTypes.ToListAsync();
                if(furnishingTypes is not null) {
                    return furnishingTypes;
                }
            }
            return new FurnishingType[]{};
        }

        public async Task<FurnishingType> FindByIdAsync(int id)
        {

            if(dc.FurnishingTypes is not null) {
                var furnishingType = await dc.FurnishingTypes.FindAsync(id);
                if(furnishingType is not null) {
                    return furnishingType;
                }
            }
            
            return new FurnishingType{};
        }

        public FurnishingType FindById(int id)
        {

            if(dc.FurnishingTypes is not null) {
                var furnishingType = dc.FurnishingTypes.Find(id);
                if(furnishingType is not null) {
                    return furnishingType;
                }
            }
            
            return new FurnishingType{};
        }

        public void Add(FurnishingType furnishingType)
        {
            if(dc.FurnishingTypes is not null && furnishingType is not null) {
                dc.FurnishingTypes.Add(furnishingType);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}