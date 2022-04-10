using hspaApi2.Data;
using hspaApi2.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;

namespace WebApi.Data.Repo
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
            if(dc.Agences is not null) {
                var agence = dc.Agences.Find(id);
                if(agence is not null) {
                    dc.Agences.Remove(agence);
                }
            }
        }

        public async Task<Agence?> FindByIdAsync(int id)
        {
            if(dc.Agences is not null) {
                var agence = await dc.Agences.FindAsync(id);
                if(agence is not null) {
                    return agence;
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<Agence>?> GetAllAsync()
        {
             if(dc.Agences is not null) {
                var agences = await dc.Agences.ToListAsync();
                if(agences is not null) {
                    return agences;
                }
            }
            return null;
        }
    }
}