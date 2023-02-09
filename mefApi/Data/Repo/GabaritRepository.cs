using Microsoft.EntityFrameworkCore;
using mefApi.Interfaces;
using mefApi.Models;

namespace mefApi.Data.Repo
{
    public class GabaritRepository : IGabaritRepository
    {
        public readonly DataContext dc;

        public GabaritRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(Gabarit gabarit)
        {
            if(dc.Gabarits is not null && gabarit is not null) {
                dc.Gabarits.Add(gabarit);
            }
        }

        public void Delete(int id)
        {
            if(dc.Gabarits is not null) {
                var gabarit = dc.Gabarits.Find(id);
                if(gabarit is not null) {
                    dc.Gabarits.Remove(gabarit);
                }
            }
        }

        public async Task<Gabarit?> FindByIdAsync(int? id)
        {
            if(dc.Gabarits is not null) {
                var gabarit = await dc.Gabarits
                .Include(m => m.Operations)
                .Where(m => m.Id == id)
                .FirstAsync();
                if(gabarit is not null) {
                    return gabarit;
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<Gabarit>?> GetAllAsync()
        {
            if(dc.Gabarits is not null) {
                var gabarits = await dc.Gabarits
                .ToListAsync();
                if(gabarits is not null) {
                    return gabarits;
                }
            }
            return null;
        }
    }
}