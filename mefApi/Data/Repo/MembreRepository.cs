using Microsoft.EntityFrameworkCore;
using mefApi.Interfaces;
using mefApi.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace mefApi.Data.Repo
{
    public class MembreRepository : IMembreRepository
    {
        public readonly DataContext dc;

        public MembreRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(Membre membre)
        {
            if(dc.Membres is not null && membre is not null) {
                dc.Membres.AddAsync(membre);
            }
        }

        public void Delete(int id)
        {
            if(dc.Membres is not null) {
                var membre = dc.Membres.Find(id);
                if(membre is not null) {
                    dc.Membres.Remove(membre);
                }
            }
        }

        public async Task<Membre?> FindByIdAsync(int? id)
        {
            if(dc.Membres is not null && id is not null) {
                var membre = await dc.Membres
                .Include(m => m.Sexe)
                .Include(m => m.Poste)
                .Include(m => m.LieuAffectation)
                .Where(s => s.Id == id)
                .FirstAsync();
                if(membre is not null) {
                    return membre;
                }
            }

            return null;
        }

        public async Task<IEnumerable<Membre>?> GetAllAsync()
        {
            if(dc.Membres is not null) {
                var membres = await dc.Membres
                .Include(m => m.Sexe)
                .Include(m => m.Poste)
                .Include(m => m.LieuAffectation)
                .ToListAsync();

                if(membres is not null){
                     return membres;
                }
            }
            
           return null;
        }

        public async Task<IEnumerable<Membre>?> GetByEtatAsync(bool estActif)
        {
            if(dc.Membres is not null) {
                var membres = await dc.Membres
                .Where(m => m.EstActif == estActif)
                .ToListAsync();
                if(membres is not null) {
                    return membres;
                }
            }

            return null;
        }

        public async Task<IEnumerable<Membre>?> GetByPosteAsync(int posteId)
        {
            if(dc.Membres is not null) {
                var membres = await dc.Membres
                .Where(s => s.PosteId == posteId)
                .ToListAsync();
                if(membres is not null) {
                    return membres;
                }
            }

            return null;
        }

        public async Task<IEnumerable<Membre>?> GetBySexeAsync(int sexeId)
        {
            if(dc.Membres is not null) {
                var membres = await dc.Membres
                .Where(m => m.SexeId == sexeId)
                .ToListAsync();
                if(membres is not null) {
                    return membres;
                }
            }

            return null;
        }
    }
}