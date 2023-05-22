using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data.Repo
{
    public class MvtAvanceDebourseRepository : IMvtAvanceDebourseRepository
    {
        public readonly DataContext dc;

        public MvtAvanceDebourseRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(MvtAvanceDebourse mvtAvance)
        {
            if(dc.MvtAvancesDebourses is not null && mvtAvance is not null) {
                dc.MvtAvancesDebourses.AddAsync(mvtAvance);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MvtAvanceDebourse?> FindByIdAsync(int? id)
        {
            if(dc.MvtAvancesDebourses is not null 
            && dc.AvancesDebourses is not null 
            && dc.Avances is not null) {
                var mouvement = await dc.MvtAvancesDebourses
                .Include(m => m.AvanceDebourse)
                .Include(m => m.Mouvement)
                .Where(m => m.Id == id)
                .FirstAsync();
                if(mouvement is not null) {
                    return mouvement;
                }
            }

            return null;
        }

        public async Task<IEnumerable<MvtAvanceDebourse>?> GetAllAsync()
        {
            if(dc.MvtAvancesDebourses is not null ) {
                var avances = await dc.MvtAvancesDebourses
                .Include(m => m.AvanceDebourse)
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