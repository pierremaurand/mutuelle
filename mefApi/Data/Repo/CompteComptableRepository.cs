using Microsoft.EntityFrameworkCore;
using mefApi.Interfaces;
using mefApi.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace mefApi.Data.Repo
{
    public class CompteComptableRepository : ICompteComptableRepository
    {
        public readonly DataContext dc;

        public CompteComptableRepository(DataContext dc)
        {
            this.dc = dc;
        }



        public void Add(CompteComptable comptecomptable)
        {
            if(dc.CompteComptables is not null && comptecomptable is not null) {
                dc.CompteComptables.AddAsync(comptecomptable);
            }
        }

        public void Delete(int id)
        {
            if(dc.CompteComptables is not null) {
                var comptecomptable = dc.CompteComptables.Find(id);
                if(comptecomptable is not null) {
                    dc.CompteComptables.Remove(comptecomptable);
                }
            }
        }

        public async Task<CompteComptable?> FindByIdAsync(int id)
        {
            if(dc.CompteComptables is not null) {
                var comptecomptable = await dc.CompteComptables
                .Where(s => s.Id == id)
                .FirstAsync();
                if(comptecomptable is not null) {
                    return comptecomptable;
                }
            }

            return null;
        }

        public async Task<IEnumerable<CompteComptable>?> GetAllAsync()
        {
            if(dc.CompteComptables is not null) {
                var comptecomptables = await dc.CompteComptables
                .ToListAsync();
                if(comptecomptables is not null) {
                    return comptecomptables;
                }
            }
            return null;
        }
    }
}