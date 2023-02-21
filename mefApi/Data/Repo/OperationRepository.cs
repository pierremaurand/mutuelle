using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data.Repo
{
    public class OperationRepository : IOperationRepository
    {
        public readonly DataContext dc;

        public OperationRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(Operation operation)
        {
            if(dc.Operations is not null && operation is not null) {
                dc.Operations.AddAsync(operation);
            }
        }

        public void Delete(int id)
        {
            if(dc.Operations is not null) {
                var operation = dc.Operations.Find(id);
                if(operation is not null) {
                    dc.Operations.Remove(operation);
                }
            }
        }

        public async Task<Operation?> FindByIdAsync(int id)
        {
            if(dc.Operations is not null) {
                var operation = await dc.Operations
                .Where(s => s.Id == id)
                .FirstAsync();
                if(operation is not null) {
                    return operation;
                }
            }

            return null;
        }

        public async Task<IEnumerable<Operation>?> GetAllAsync()
        {
            if(dc.Operations is not null) {
                var operations = await dc.Operations
                .ToListAsync();
                if(operations is not null) {
                    return operations;
                }
            }

            return null;
        }

        public async Task<IEnumerable<Operation>?> GetByGabaritAsync(int gabaritId)
        {
            if(dc.Operations is not null) {
                var operations = await dc.Operations
                .Where(o => o.GabaritId == gabaritId)
                .ToListAsync();
                if(operations is not null) {
                    return operations;
                }
            }

            return null;
        }
    }
}