using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Interfaces;
using mefApi.Models;

namespace mefApi.Data.Repo
{
    public class CreditDebourseRepository : ICreditDebourseRepository
    {
        public readonly DataContext dc;

        public CreditDebourseRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(CreditDebourse credit)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CreditDebourse?> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CreditDebourse>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}