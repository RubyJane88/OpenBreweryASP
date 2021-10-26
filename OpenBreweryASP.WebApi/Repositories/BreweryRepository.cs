using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OpenBreweryASP.Contracts;
using OpenBreweryASP.Models;
using OpenBreweryASP.Models.Dtos;
using OpenBreweryASP.Models.Entities;

namespace OpenBreweryASP.Repositories
{
    public class BreweryRepository : IBreweryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BreweryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<BreweryDto>> GetAllAsync()
        {
            try
            {
                var breweries = await _context.Breweries.ToListAsync();
                var breweryDto = _mapper.Map<IEnumerable<BreweryDto>>(breweries);

                return breweryDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting the breweries");
            }
        }

        public async Task<BreweryDto> GetBreweryByCityAsync(string city)
        {
            try
            {

                var exists = await ExistsByCityAsync(city);
                if (exists)
                {
                    
                    var brewery = await _context.Breweries.FirstOrDefaultAsync(b => b.City == city);
                    var breweryDto = _mapper.Map<BreweryDto>(brewery);
                    return breweryDto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error in getting brewery in that city");
            }
        }

        public async Task<BreweryDto> CreateAsync(Brewery brewery)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BreweryDto> UpdateAsync(Brewery brewery)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> ExistsByCityAsync(string city) => await _context.Breweries.AnyAsync(t => t.City == city);
    }
}