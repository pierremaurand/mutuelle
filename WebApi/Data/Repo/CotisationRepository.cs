using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Data.Repo
{
    public class CotisationRepository : ICotisationRepository
    {
        public readonly DataContext dc;

        public CotisationRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(Cotisation cotisation)
        {
            if(dc.Cotisations is not null && cotisation is not null) {
                dc.Cotisations.Add(cotisation);
            }
        }

        public void Delete(int id)
        {
            if(dc.Cotisations is not null) {
                var cotisation = dc.Cotisations.Find(id);
                if(cotisation is not null) {
                    dc.Cotisations.Remove(cotisation);
                }
            }
        }

        public async Task<Cotisation?> FindByIdAsync(int id)
        {
            if(dc.Cotisations is not null) {
                var cotisation = await dc.Cotisations.FindAsync(id);
                if(cotisation is not null) {
                    return cotisation;
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<Cotisation>?> GetAllAsync()
        {
             if(dc.Cotisations is not null) {
                var cotisations = await dc.Cotisations.ToListAsync();
                if(cotisations is not null) {
                    return cotisations;
                }
            }
            return null;
        }
    }
}