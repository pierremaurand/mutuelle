using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data.Repo
{
    public class MvtCompteRepository : IMvtCompteRepository
    {
        public readonly DataContext dc;

        public MvtCompteRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(MvtCompte mvtcompte)
        {
            if(dc.MvtComptes is not null && mvtcompte is not null) {
                dc.MvtComptes.AddAsync(mvtcompte);
            }
        }

        public void Delete(int id)
        {
            if(dc.MvtComptes is not null) {
                var mvtcompte = dc.MvtComptes.Find(id);
                if(mvtcompte is not null) {
                    dc.MvtComptes.Remove(mvtcompte);
                }
            }
        }

        public async Task<MvtCompte?> FindByIdAsync(int id)
        {
            if(dc.MvtComptes is not null) {
                var compte = await dc.MvtComptes
                .Where(s => s.Id == id)
                .FirstAsync();
                if(compte is not null) {
                    return compte;
                }
            }

            return null;
        }

        public async Task<IEnumerable<MvtCompte>?> GetAllAsync()
        {
            if(dc.MvtComptes is not null) {
                var mvtcomptes = await dc.MvtComptes
                .ToListAsync();
                if(mvtcomptes is not null) {
                    return mvtcomptes;
                }
            }

            return null;
        }

        public async Task<IEnumerable<MvtCompte>?> GetByCompteAsync(int compteId)
        {
            if(dc.MvtComptes is not null) {
                var mvtcomptes = await dc.MvtComptes
                .Where(c => c.CompteId == compteId)
                .ToListAsync();
                if(mvtcomptes is not null) {
                    return mvtcomptes;
                }
            }

            return null;
        }
    }
}