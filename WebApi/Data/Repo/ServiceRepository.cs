using hspaApi2.Data;
using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Data.Repo
{
    public class ServiceRepository : IServiceRepository
    {
        public readonly DataContext dc;

        public ServiceRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void Add(Service service)
        {
            if(dc.Services is not null && service is not null) {
                dc.Services.Add(service);
            }
        }

        public void Delete(int id)
        {
            if(dc.Services is not null) {
                var service = dc.Services.Find(id);
                if(service is not null) {
                    dc.Services.Remove(service);
                }
            }
        }

        public async Task<Service?> FindByIdAsync(int id)
        {
            if(dc.Services is not null) {
                var service = await dc.Services.FindAsync(id);
                if(service is not null) {
                    return service;
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<Service>?> GetAllAsync()
        {
            if(dc.Services is not null) {
                var services = await dc.Services.ToListAsync();
                if(services is not null) {
                    return services;
                }
            }
            return null;
        }
    }
}