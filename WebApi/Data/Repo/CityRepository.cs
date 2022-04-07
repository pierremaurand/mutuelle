using System.Collections.Generic;
using hspaApi2.Interfaces;
using hspaApi2.Models;
using Microsoft.EntityFrameworkCore;

namespace hspaApi2.Data.Repo
{
    public class CityRepository : ICityRepository
    {
        public readonly DataContext dc;
        public CityRepository(DataContext dc) 
        {
            this.dc = dc;  
        }

        public void Add(City city)
        {
            if(dc.Cities is not null && city is not null) {
                dc.Cities.AddAsync(city);
            }
        }

        public void Delete(int cityId)
        {
            if(dc.Cities is not null) {
                var city = dc.Cities.Find(cityId);
                if(city is not null) {
                    dc.Cities.Remove(city);
                }
            }
        }

        public async Task<City> FindByIdAsync(int id)
        {

            if(dc.Cities is not null) {
                var city = await dc.Cities.FindAsync(id);
                if(city is not null) {
                    return city;
                }
            }
            
            return new City{};
        }

        public City FindById(int id)
        {
            if(dc.Cities is not null) {
                var city = dc.Cities.Find(id);
                if(city is not null) {
                    return city;
                }
            }
            return new City{};
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            if(dc.Cities is not null) {
                var cities = await dc.Cities.ToListAsync();
                if(cities is not null) {
                    return cities;
                }
            }
            return new City[]{};
        }
        
    }
}