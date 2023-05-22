using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data.Repo
{
    public class MvtEcheanceCreditRepository : IMvtEcheanceCreditRepository
    {
        public readonly DataContext dc;

        public MvtEcheanceCreditRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(MvtEcheanceCredit echeance)
        {
            if(dc.MvtEcheancesCredits is not null && echeance is not null) {
                dc.MvtEcheancesCredits.AddAsync(echeance);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MvtEcheanceCredit?> FindByIdAsync(int? id)
        {
            if(dc.MvtEcheancesCredits is not null) {
                var mouvement = await dc.MvtEcheancesCredits
                .Include(m => m.EcheanceCredit)
                .Include(m => m.Mouvement)
                .Where(m => m.Id == id)
                .FirstAsync();
                if(mouvement is not null) {
                    return mouvement;
                }
            }

            return null;
        }

        public async Task<IEnumerable<MvtEcheanceCredit>?> GetAllAsync()
        {
            if(dc.MvtEcheancesCredits is not null) {
                var avances = await dc.MvtEcheancesCredits
                .Include(m => m.EcheanceCredit)
                .Include(m => m.Mouvement)
                .ToListAsync();
                if(avances is not null) {
                    return avances;
                }
            }

            return null;
        }
    }
}