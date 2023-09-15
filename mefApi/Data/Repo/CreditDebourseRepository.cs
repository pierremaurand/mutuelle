using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data.Repo
{
    public class CreditDebourseRepository : ICreditDebourseRepository
    {
        public readonly DataContext dc;

        public CreditDebourseRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(CreditDebourse credit)
        {
            if(dc.CreditsDebourses is not null && credit is not null) {
                dc.CreditsDebourses.AddAsync(credit);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CreditDebourse?> FindByIdAsync(int id)
        {
            if(dc.CreditsDebourses is not null) {
                var credit = await dc.CreditsDebourses
                .Include(a => a.Credit)
                .Include(a => a.Mouvement)
                .Where(a => a.Id == id)
                .FirstAsync();
                if(credit is not null) {
                    return credit;
                }
            }
            return null;
        }

        public async Task<IEnumerable<CreditDebourse>?> GetAllAsync()
        {
            if(dc.CreditsDebourses is not null) {
                var credits = await dc.CreditsDebourses
                .Include(a => a.Mouvement)
                .ToListAsync();
                if(credits is not null) {
                    return credits;
                }
            }
            return null;
        }
    }
}