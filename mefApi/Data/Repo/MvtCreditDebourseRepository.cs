using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data.Repo
{
    public class MvtCreditDebourseRepository : IMvtCreditDebourseRepository
    {
        public readonly DataContext dc;

        public MvtCreditDebourseRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(MvtCreditDebourse mvtCredit)
        {
            if(dc.MvtCreditsDebourses is not null && mvtCredit is not null) {
                dc.MvtCreditsDebourses.AddAsync(mvtCredit);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MvtCreditDebourse?> FindByIdAsync(int? id)
        {
            if(dc.MvtCreditsDebourses is not null) {
                var mouvement = await dc.MvtCreditsDebourses
                .Include(m => m.CreditDebourse)
                .Include(m => m.Mouvement)
                .Where(m => m.Id == id)
                .FirstAsync();
                if(mouvement is not null) {
                    return mouvement;
                }
            }

            return null;
        }

        public async Task<IEnumerable<MvtCreditDebourse>?> GetAllAsync()
        {
            if(dc.MvtCreditsDebourses is not null) {
                var avances = await dc.MvtCreditsDebourses
                .Include(m => m.CreditDebourse)
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