using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Interfaces;
using mefApi.Models;

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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AvanceDebourse?> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AvanceDebourse>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}