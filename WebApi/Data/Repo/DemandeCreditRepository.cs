using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Data.Repo
{
    public class DemandeCreditRepository : IDemandeCreditRepository
    {
        public readonly DataContext dc;

        public DemandeCreditRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(DemandeCredit demandecredit)
        {
            if(dc.DemandeCredits is not null && demandecredit is not null) {
                dc.DemandeCredits.Add(demandecredit);
            }
        }

        public void Delete(int id)
        {
            if(dc.DemandeCredits is not null) {
                var demandecredit = dc.DemandeCredits.Find(id);
                if(demandecredit is not null) {
                    dc.DemandeCredits.Remove(demandecredit);
                }
            }
        }

        public async Task<DemandeCredit?> FindByIdAsync(int id)
        {
            if(dc.DemandeCredits is not null) {
                var demandecredit = await dc.DemandeCredits.FindAsync(id);
                if(demandecredit is not null) {
                    return demandecredit;
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<DemandeCredit>?> GetAllAsync()
        {
             if(dc.DemandeCredits is not null) {
                var demandecredits = await dc.DemandeCredits.ToListAsync();
                if(demandecredits is not null) {
                    return demandecredits;
                }
            }
            return null;
        }
    }
}