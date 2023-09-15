using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            if(dc.EcheancesCredits is not null && echeancecredit is not null) {
                dc.EcheancesCredits.AddAsync(echeancecredit);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EcheanceCredit?> FindByIdAsync(int id)
        {
            if(dc.EcheancesCredits is not null) {
                var echeance = await dc.EcheancesCredits
                .Include(s => s.Mouvements)
                .Include(s => s.Credit)
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
            if(dc.EcheancesCredits is not null) {
                var echeances = await dc.EcheancesCredits
                .ToListAsync();
                if(echeances is not null) {
                    return echeances;
                }
            }

            return null;
        }

        public async Task<IEnumerable<EcheanceCredit>?> GetAllByCreditAsync(int creditId)
        {
            if(dc.EcheancesCredits is not null) {
                var echeances = await dc.EcheancesCredits
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