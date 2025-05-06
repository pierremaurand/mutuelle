using Microsoft.EntityFrameworkCore;
using mefApi.Interfaces;
using mefApi.Models;

namespace mefApi.Data.Repo
{
    public class AgenceRepository : IAgenceRepository
    {
         public readonly DataContext dc;

        public AgenceRepository(DataContext dc)
        {
            this.dc = dc;
        }



        public void Add(Agence agence)
        {
            if(dc.Agences is not null && agence is not null) {
                dc.Agences.Add(agence);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Agence?> FindByIdAsync(int id)
        {
            if(dc.Agences is not null) {
                var agence = await dc.Agences
                .Where(s => s.Id == id)
                .FirstAsync();
                if(agence is not null) {
                    return agence;
                }
            }

            return null;
        }
        public async Task<Agence?> FindByNomAsync(string nom)
        {
            if(dc.Agences is not null) {
                var agence = await dc.Agences
                .Where(s => s.Nom == nom)
                .FirstAsync();
                if(agence is not null) {
                    return agence;
                }
            }

            return null;
        }

        public async Task<IEnumerable<Agence>?> GetAllAsync()
        {
            if(dc.Agences is not null) {
                var agences = await dc.Agences
                .ToListAsync();
                if(agences is not null) {
                    return agences;
                }
            }
            return null;
        }

        public async Task<bool> AgenceExists(string nom)
        {
            if(dc.Agences is not null)
                return await dc.Agences.AnyAsync(x => x.Nom == nom);
            return false;
        }
    }
}