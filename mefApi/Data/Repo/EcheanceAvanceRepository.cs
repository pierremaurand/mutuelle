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
            if(dc.EcheanceAvances is not null && echeanceavance is not null) {
                dc.EcheanceAvances.AddAsync(echeanceavance);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EcheanceAvance?> FindByIdAsync(int id)
        {
            if(dc.EcheanceAvances is not null) {
                var echeance = await dc.EcheanceAvances
                .Where(s => s.Id == id)
                .FirstAsync();
                if(echeance is not null) {
                    return echeance;
                }
            }

            return null;
        }

        public async Task<IEnumerable<EcheanceAvance>?> GetAllAsync()
        {
            if(dc.EcheanceAvances is not null) {
                var echeances = await dc.EcheanceAvances
                .ToListAsync();
                if(echeances is not null) {
                    return echeances;
                }
            }

            return null;
        }

        public async Task<IEnumerable<EcheanceAvance>?> GetAllByAvanceAsync(int avanceId)
        {
            if(dc.EcheanceAvances is not null) {
                var echeances = await dc.EcheanceAvances
                .Where(c => c.AvanceId == avanceId)
                .ToListAsync();
                if(echeances is not null) {
                    return echeances;
                }
            }

            return null;
        }
    }
}