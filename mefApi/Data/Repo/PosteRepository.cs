using Microsoft.EntityFrameworkCore;
using mefApi.Interfaces;
using mefApi.Models;

namespace mefApi.Data.Repo
{
    public class PosteRepository : IPosteRepository
    {
        public readonly DataContext dc;

        public PosteRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(Poste poste)
        {
            if(dc.Postes is not null && poste is not null) {
                dc.Postes.Add(poste);
            }
        }

        public void Delete(int id)
        {
            if(dc.Postes is not null) {
                var poste = dc.Postes.Find(id);
                if(poste is not null) {
                    dc.Postes.Remove(poste);
                }
            }
        }

        public async Task<Poste?> FindByIdAsync(int id)
        {
            if(dc.Postes is not null) {
                var poste = await dc.Postes.FindAsync(id);
                if(poste is not null) {
                    return poste;
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<Poste>?> GetAllAsync()
        {
            if (dc.Postes is not null)
            {
                var postes = await dc.Postes.ToListAsync();
                if (postes is not null)
                {
                    return postes;
                }
            }
            return null;
        }
    }
}