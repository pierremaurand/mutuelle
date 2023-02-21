using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data.Repo
{
    public class CompteRepository : ICompteRepository
    {
        public readonly DataContext dc;

        public CompteRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(Compte compte)
        {
            if(dc.Comptes is not null && compte is not null) {
                dc.Comptes.AddAsync(compte);
            }
        }

        public void Delete(int id)
        {
            if(dc.Comptes is not null) {
                var compte = dc.Comptes.Find(id);
                if(compte is not null) {
                    dc.Comptes.Remove(compte);
                }
            }
        }

        public async Task<Compte?> FindByIdAsync(int id)
        {
            if(dc.Comptes is not null) {
                var compte = await dc.Comptes
                .Where(s => s.Id == id)
                .FirstAsync();
                if(compte is not null) {
                    return compte;
                }
            }

            return null;
        }

        public async Task<IEnumerable<Compte>?> GetAllAsync()
        {
           if(dc.Comptes is not null) {
                var comptes = await dc.Comptes
                .ToListAsync();
                if(comptes is not null) {
                    return comptes;
                }
            }

            return null;
        }
    }
}