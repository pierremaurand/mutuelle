using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data.Repo
{
    public class MoisRepository : IMoisRepository
    {
        public readonly DataContext dc;

        public MoisRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<Mois>?> GetAllAsync()
        {
            if(dc.Mois is not null) {
                var mois = await dc.Mois
                .ToListAsync();
                if(mois is not null) {
                    return mois;
                }
            }

            return null;
        }
    }
}