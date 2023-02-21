using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IOperationRepository
    {
        Task<IEnumerable<Operation>?> GetAllAsync();
        Task<IEnumerable<Operation>?> GetByGabaritAsync(int gabaritId);
        void Add(Operation operation);
        void Delete(int id);
        Task<Operation?> FindByIdAsync(int id);
 
    }
}