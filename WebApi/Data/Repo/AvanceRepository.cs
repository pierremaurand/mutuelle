using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Data.Repo
{
    public class AvanceRepository : IAvanceRepository
    {
        public readonly DataContext dc;

        public AvanceRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(Avance avance)
        {
            if (dc.Avances is not null && avance is not null)
            {
                dc.Avances.Add(avance);
            }
        }

        public void Delete(int id)
        {
            if (dc.Avances is not null)
            {
                var avance = dc.Avances.Find(id);
                if (avance is not null)
                {
                    dc.Avances.Remove(avance);
                }
            }
        }

        public async Task<Avance?> FindByIdAsync(int id)
        {
            if (dc.Avances is not null)
            {
                var avance = await dc.Avances
                .Include(m => m.EcheanceAvances)
                .Where(m => m.Id == id)
                .FirstAsync();
                if (avance is not null)
                {
                    return avance;
                }
            }

            return null;
        }

        public async Task<IEnumerable<Avance>?> GetAllAsync()
        {
            if (dc.Avances is not null)
            {
                var avances = await dc.Avances
                .Include(m => m.EcheanceAvances)
                .ToListAsync();
                if (avances is not null)
                {
                    return avances;
                }
            }
            return null;
        }

        public async Task<IEnumerable<Avance>?> GetAllByMembreAsync(int membreId)
        {
            if (dc.Avances is not null)
            {
                var avances = await dc.Avances
                .Include(m => m.EcheanceAvances)
                .Where(c => c.MembreId == membreId)
                .ToListAsync();
                if (avances is not null)
                {
                    return avances;
                }
            }
            return null;
        }
    }
}