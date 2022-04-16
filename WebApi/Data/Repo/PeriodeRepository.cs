using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Data.Repo
{
    public class PeriodeRepository: IPeriodeRepository
    {
        public readonly DataContext dc;

        public PeriodeRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(Periode periode)
        {
            if(dc.Periodes is not null && periode is not null) {
                dc.Periodes.Add(periode);
            }
        }

        public void Delete(int id)
        {
            if(dc.Periodes is not null) {
                var periode = dc.Periodes.Find(id);
                if(periode is not null) {
                    dc.Periodes.Remove(periode);
                }
            }
        }

        public async Task<Periode?> FindByIdAsync(int id)
        {
            if(dc.Periodes is not null) {
                var periode = await dc.Periodes.FindAsync(id);
                if(periode is not null) {
                    return periode;
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<Periode>?> GetAllAsync()
        {
             if(dc.Periodes is not null) {
                var periodes = await dc.Periodes.ToListAsync();
                if(periodes is not null) {
                    return periodes;
                }
            }
            return null;
        }
    }
}