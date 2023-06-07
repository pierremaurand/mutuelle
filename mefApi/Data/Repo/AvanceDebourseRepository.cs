using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data.Repo
{
    public class AvanceDebourseRepository : IAvanceDebourseRepository
    {
        public readonly DataContext dc;

        public AvanceDebourseRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(AvanceDebourse avance)
        {
            if(dc.AvancesDebourses is not null && avance is not null) {
                dc.AvancesDebourses.AddAsync(avance);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AvanceDebourse?> FindByIdAsync(int id)
        {
            if(dc.AvancesDebourses is not null) {
                var avance = await dc.AvancesDebourses
                .Include(a => a.Mouvement)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
                if(avance is not null) {
                    return avance;
                }
            }

            return null;
        }

        public async Task<IEnumerable<AvanceDebourse>?> FindByAvanceIdAsync(int id) {
            if(dc.AvancesDebourses is not null) {
                var avance = await dc.AvancesDebourses
                .Include(a => a.Mouvement)
                .Where(a => a.AvanceId == id)
                .ToListAsync();
                if(avance is not null) {
                    return avance;
                }
            }

            return null;
        }

        public async Task<IEnumerable<AvanceDebourse>?> GetAllAsync()
        {
            if(dc.AvancesDebourses is not null) {
                var avances = await dc.AvancesDebourses
                .Include(a => a.Mouvement)
                .ToListAsync();
                if(avances is not null) {
                    return avances;
                }
            }

            return null;
        }
    }
}