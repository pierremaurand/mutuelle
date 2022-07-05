using Microsoft.EntityFrameworkCore;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Data.Repo
{
    public class MembreRepository : IMembreRepository
    {
        public readonly DataContext dc;

        public MembreRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(Membre membre)
        {
            if(dc.Membres is not null && membre is not null) {
                dc.Membres.Add(membre);
            }
        }

        public void Delete(int id)
        {
             if(dc.Membres is not null) {
                var membre = dc.Membres.Find(id);
                if(membre is not null) {
                    dc.Membres.Remove(membre);
                }
            }
        }

        public async Task<Membre?> FindByIdAsync(int id)
        {
            if(dc.Membres is not null) {
                var membre = await dc.Membres
                .Include(m => m.Agence)
                .Include(m => m.Service)
                .Include(m => m.Sexe)
                .Include(m => m.Cotisations.Where(c => c.EstValide))
                .Include(m => m.Avances)
                .Include(m => m.Credits)
                .Where(m => m.Id == id)
                .FirstAsync();
                if(membre is not null) {
                    return membre;
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<Membre>?> GetAllAsync()
        {
            if(dc.Membres is not null) {
                var membres = await dc.Membres
                .Include(m => m.Agence)
                .ToListAsync();
                if(membres is not null) {
                    return membres;
                }
            }
            return null;
        }
    }
}