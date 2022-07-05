using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Data.Repo
{
    public class GabarieRepository : IGabarieRepository
    {
        public readonly DataContext dc;

        public GabarieRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(Gabarie gabarie)
        {
            if(dc.Gabaries is not null && gabarie is not null) {
                dc.Gabaries.Add(gabarie);
            }
        }

        public void Delete(int id)
        {
            if(dc.Gabaries is not null) {
                var gabarie = dc.Gabaries.Find(id);
                if(gabarie is not null) {
                    dc.Gabaries.Remove(gabarie);
                }
            }
        }

        public async Task<Gabarie?> FindByIdAsync(int id)
        {
            if(dc.Gabaries is not null) {
                var gabarie = await dc.Gabaries.FindAsync(id);
                if(gabarie is not null) {
                    return gabarie;
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<Gabarie>?> GetAllAsync()
        {
             if(dc.Gabaries is not null) {
                var gabaries = await dc.Gabaries.ToListAsync();
                if(gabaries is not null) {
                    return gabaries;
                }
            }
            return null;
        }
    }
}