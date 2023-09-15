using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data.Repo
{
    public class EcheanceAvanceRepository : IEcheanceAvanceRepository
    {
        public readonly DataContext dc;

        public EcheanceAvanceRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(EcheanceAvance echeanceavance)
        {
            if(dc.EcheancesAvances is not null && echeanceavance is not null) {
                dc.EcheancesAvances.AddAsync(echeanceavance);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EcheanceAvance?> FindByIdAsync(int id)
        {
            if(dc.EcheancesAvances is not null) {
                var echeance = await dc.EcheancesAvances
                .Include(e => e.Mouvements)
                .Include(e => e.Avance)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
                if(echeance is not null) {
                    return echeance;
                }
            }

            return null;
        }
        
        public async Task<ICollection<EcheanceAvance>?> GetALLEcheancesAvanceAsync(int id)
        {
            if(dc.EcheancesAvances is not null) {
                var echeancier = await dc.EcheancesAvances
                .Where(e => e.AvanceId == id)
                .ToListAsync();
                if(echeancier is not null) {
                    return echeancier;
                }
            }

            return null;
        }

        public async Task<IEnumerable<EcheanceAvance>?> GetAllAsync()
        {
            if(dc.EcheancesAvances is not null) {
                var echeances = await dc.EcheancesAvances
                .ToListAsync();
                if(echeances is not null) {
                    return echeances;
                }
            }

            return null;
        }
    }
}