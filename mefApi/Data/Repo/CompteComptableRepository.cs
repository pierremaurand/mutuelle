using Microsoft.EntityFrameworkCore;
using mefApi.Interfaces;
using mefApi.Models;

namespace mefApi.Data.Repo
{
    public class CompteComptableRepository : ICompteComptableRepository
    {
        public readonly DataContext dc;

        public CompteComptableRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(CompteComptable compteComptable)
        {
            if(dc.CompteComptables is not null && compteComptable is not null) {
                dc.CompteComptables.Add(compteComptable);
            }
        }

        public void Delete(int id)
        {
            if(dc.CompteComptables is not null) {
                var compte = dc.CompteComptables.Find(id);
                if(compte is not null) {
                    dc.CompteComptables.Remove(compte);
                }
            }
        }

        public async Task<CompteComptable?> FindByIdAsync(int? id)
        {
            if(dc.CompteComptables is not null) {
                var compte = await dc.CompteComptables.FindAsync(id);
                if(compte is not null) {
                    return compte;
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<CompteComptable>?> GetAllAsync()
        {
            if (dc.CompteComptables is not null)
            {
                var comptes = await dc.CompteComptables.ToListAsync();
                if (comptes is not null)
                {
                    return comptes;
                }
            }
            return null;
        }
    }
}