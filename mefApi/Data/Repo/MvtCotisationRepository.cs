using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data.Repo
{
    public class MvtCotisationRepository : IMvtCotisationRepository
    {
        public readonly DataContext dc;

        public MvtCotisationRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void Add(MvtCotisation mvtcotisation)
        {
            if(dc.MvtCotisations is not null && mvtcotisation is not null) {
                dc.MvtCotisations.AddAsync(mvtcotisation);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MvtCotisation?> FindByIdAsync(int id)
        {
            if(dc.MvtCotisations is not null) {
                var mouvement = await dc.MvtCotisations
                .Include(m => m.Cotisation)
                .Include(m => m.Mouvement)
                .Where(m => m.Id == id)
                .FirstAsync();
                if(mouvement is not null) {
                    return mouvement;
                }
            }

            return null;
        }

        public async Task<IEnumerable<MvtCotisation>?> GetAllAsync()
        {
            if(dc.MvtCotisations is not null) {
                var mouvement = await dc.MvtCotisations
                .Include(m => m.Cotisation)
                .Include(m => m.Mouvement)
                .ToListAsync();
                if(mouvement is not null) {
                    return mouvement;
                }
            }

            return null;
        }
    }
}