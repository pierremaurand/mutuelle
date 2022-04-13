using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Data.Repo
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
                dc.MvtComptes.Add(mvtcompte);
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
                var mvtcompte = await dc.MvtComptes.FindAsync(id);
                if(mvtcompte is not null) {
                    return mvtcompte;
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<MvtCompte>?> GetAllAsync()
        {
             if(dc.MvtComptes is not null) {
                var mvtcomptes = await dc.MvtComptes.ToListAsync();
                if(mvtcomptes is not null) {
                    return mvtcomptes;
                }
            }
            return null;
        }
    }
}