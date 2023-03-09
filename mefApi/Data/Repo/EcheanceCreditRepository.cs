using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data.Repo
{
    public class EcheanceCreditRepository : IEcheanceCreditRepository
    {
        public readonly DataContext dc;

        public EcheanceCreditRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(EcheanceCredit echeancecredit)
        {
            if(dc.EcheanceCredits is not null && echeancecredit is not null) {
                dc.EcheanceCredits.AddAsync(echeancecredit);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EcheanceCredit?> FindByIdAsync(int id)
        {
            if(dc.EcheanceCredits is not null) {
                var echeance = await dc.EcheanceCredits
                .Where(s => s.Id == id)
                .FirstAsync();
                if(echeance is not null) {
                    return echeance;
                }
            }

            return null;
        }

        public async Task<IEnumerable<EcheanceCredit>?> GetAllAsync()
        {
            if(dc.EcheanceCredits is not null) {
                var echeances = await dc.EcheanceCredits
                .ToListAsync();
                if(echeances is not null) {
                    return echeances;
                }
            }

            return null;
        }

        public async Task<IEnumerable<EcheanceCredit>?> GetAllByCreditAsync(int creditId)
        {
            if(dc.EcheanceCredits is not null) {
                var echeances = await dc.EcheanceCredits
                .Where(c => c.CreditId == creditId)
                .ToListAsync();
                if(echeances is not null) {
                    return echeances;
                }
            }

            return null;
        }
    }
}