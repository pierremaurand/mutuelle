using Microsoft.EntityFrameworkCore;
using mefApi.Interfaces;
using mefApi.Models;

namespace mefApi.Data.Repo
{
    public class SexeRepository : ISexeRepository
    {
        public readonly DataContext dc;

        public SexeRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(Sexe sexe)
        {
            if(dc.Sexes is not null && sexe is not null) {
                dc.Sexes.Add(sexe);
            }
        }

        public void Delete(int id)
        {
            if(dc.Sexes is not null) {
                var sexe = dc.Sexes.Find(id);
                if(sexe is not null) {
                    dc.Sexes.Remove(sexe);
                }
            }
        }

        public async Task<Sexe?> FindByIdAsync(int id)
        {
            if(dc.Sexes is not null) {
                var sexe = await dc.Sexes
                .Where(s => s.Id == id)
                .FirstAsync();
                if(sexe is not null) {
                    return sexe;
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<Sexe>?> GetAllAsync()
        {
            if(dc.Sexes is not null) {
                var sexes = await dc.Sexes
                .ToListAsync();
                if(sexes is not null) {
                    return sexes;
                }
            }
            return null;
        }
    }
}