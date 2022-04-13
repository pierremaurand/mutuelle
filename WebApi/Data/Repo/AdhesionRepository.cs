using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Data.Repo
{
    public class AdhesionRepository : IAdhesionRepository
    {
        public readonly DataContext dc;

        public AdhesionRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(Adhesion adhesion)
        {
            if(dc.Adhesions is not null && adhesion is not null) {
                dc.Adhesions.Add(adhesion);
            }
        }

        public void Delete(int id)
        {
            if(dc.Adhesions is not null) {
                var adhesion = dc.Adhesions.Find(id);
                if(adhesion is not null) {
                    dc.Adhesions.Remove(adhesion);
                }
            }
        }

        public async Task<Adhesion?> FindByIdAsync(int id)
        {
            if(dc.Adhesions is not null) {
                var adhesion = await dc.Adhesions.FindAsync(id);
                if(adhesion is not null) {
                    return adhesion;
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<Adhesion>?> GetAllAsync()
        {
             if(dc.Adhesions is not null) {
                var adhesions = await dc.Adhesions.ToListAsync();
                if(adhesions is not null) {
                    return adhesions;
                }
            }
            return null;
        }
    }
}