using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data.Repo
{
    public class MvtEcheanceAvanceRepository : IMvtEcheanceAvanceRepository
    {
        public readonly DataContext dc;

        public MvtEcheanceAvanceRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(MvtEcheanceAvance echeance)
        {
            if(dc.MvtEcheancesAvances is not null && echeance is not null) {
                dc.MvtEcheancesAvances.AddAsync(echeance);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MvtEcheanceAvance?> FindByIdAsync(int? id)
        {
            if(dc.MvtEcheancesAvances is not null) {
                var mouvement = await dc.MvtEcheancesAvances
                .Include(m => m.EcheanceAvance)
                .Include(m => m.Mouvement)
                .Where(m => m.Id == id)
                .FirstAsync();
                if(mouvement is not null) {
                    return mouvement;
                }
            }

            return null;
        }

        public async Task<IEnumerable<MvtEcheanceAvance>?> GetAllAsync()
        {
            if(dc.MvtEcheancesAvances is not null) {
                var avances = await dc.MvtEcheancesAvances
                .Include(m => m.EcheanceAvance)
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