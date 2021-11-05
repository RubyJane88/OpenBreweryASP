using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<BreweryDto>> GetBreweryByCityAsync(string city)
        {
            try
            {

                var existsByCityAsync = await ExistsByCityAsync(city);
                if (existsByCityAsync)
                {
                    var breweries = await _context.Breweries.Where(b => b.City == city).ToListAsync();
                    var breweryDto = _mapper.Map<IEnumerable<BreweryDto>>(breweries);

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


        public async Task <IEnumerable<BreweryDto>> GetBreweriesByStateAsync(string state)
        {
            try
            {

                var exists = await ExistsByStateAsync(state);
                if (exists)
                {
                    var breweriesByState = await _context.Breweries.Where(b => b.State == state).ToListAsync();
                    var result = _mapper.Map <IEnumerable<BreweryDto>>(breweriesByState);
                    return result;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting brewery in that state"); 
            }
        }

        public async Task <IEnumerable <BreweryDto>> GetBreweriesByTypeAsync(string type)
        {
            try
            {
                var exists = await ExistsByTypeAsync(type);
                if (exists)
                {
                    var breweriesByType = await _context.Breweries.Where(b => b.BreweryType == type).ToListAsync();
                    var breweryDto = _mapper.Map <IEnumerable<BreweryDto>>(breweriesByType);
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
                throw new Exception("Error getting brewery type");
            }
        }

        public async Task<BreweryDto> CreateAsync(Brewery brewery)
        {
            try
            {
                _context.Breweries.Add(brewery);
                
                await _context.SaveChangesAsync();

                var breweryDto = _mapper.Map<BreweryDto>(brewery);
                return breweryDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error creating new brewery");
            }
        }

        //refactored it to return bool to check if id is not null
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var exists = await ExistsByIdAsync(id);
                if (exists)
                {
                    _context.Remove(await _context.Breweries.FindAsync(id));
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error deleting brewery");
            }
        }
        
        
        public async Task<BreweryDto> UpdateAsync(Brewery brewery)
        {
            try
            {
                var exists = await ExistsByIdAsync(brewery.Id);
                if (!exists) throw new Exception("Not found");

                _context.Update(brewery);
                await _context.SaveChangesAsync();
                var breweryDto = _mapper.Map<BreweryDto>(brewery);
                return breweryDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error updating the brewery");
            }
        }

        public async Task<bool> ExistsByCityAsync(string city) => await _context.Breweries.AnyAsync(b => b.City == city);
        
        public async Task<bool> ExistsByStateAsync(string state) => await _context.Breweries.AnyAsync(b => b.State == state);

        public async Task<bool> ExistsByTypeAsync(string type) => await _context.Breweries
            .AnyAsync(b => b.BreweryType == type);
        

        public async Task<bool> ExistsByIdAsync(Guid id) => await _context.Breweries.AnyAsync(b => b.Id == id);
    }
}