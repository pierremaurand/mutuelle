using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Data.Repo
{
    public class CreditRepository : ICreditRepository
    {
        public readonly DataContext dc;

        public CreditRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(Credit credit)
        {
            if(dc.Credits is not null && credit is not null) {
                dc.Credits.Add(credit);
            }
        }

        public void Delete(int id)
        {
            if(dc.Credits is not null) {
                var credit = dc.Credits.Find(id);
                if(credit is not null) {
                    dc.Credits.Remove(credit);
                }
            }
        }

        public async Task<Credit?> FindByIdAsync(int id)
        {
            if(dc.Credits is not null) {
                var credit = await dc.Credits.FindAsync(id);
                if(credit is not null) {
                    return credit;
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<Credit>?> GetAllAsync()
        {
             if(dc.Credits is not null) {
                var credits = await dc.Credits.ToListAsync();
                if(credits is not null) {
                    return credits;
                }
            }
            return null;
        }
    }
}