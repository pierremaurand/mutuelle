using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Data.Repo
{
    public class DemandeAvanceRepository : IDemandeAvanceRepository
    {
        public readonly DataContext dc;

        public DemandeAvanceRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(DemandeAvance demandeavance)
        {
            if(dc.DemandeAvances is not null && demandeavance is not null) {
                dc.DemandeAvances.Add(demandeavance);
            }
        }

        public void Delete(int id)
        {
            if(dc.DemandeAvances is not null) {
                var demandeavance = dc.DemandeAvances.Find(id);
                if(demandeavance is not null) {
                    dc.DemandeAvances.Remove(demandeavance);
                }
            }
        }

        public async Task<DemandeAvance?> FindByIdAsync(int id)
        {
            if(dc.DemandeAvances is not null) {
                var demandeavance = await dc.DemandeAvances.FindAsync(id);
                if(demandeavance is not null) {
                    return demandeavance;
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<DemandeAvance>?> GetAllAsync()
        {
             if(dc.DemandeAvances is not null) {
                var demandeavances = await dc.DemandeAvances.ToListAsync();
                if(demandeavances is not null) {
                    return demandeavances;
                }
            }
            return null;
        }
    }
}