using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenBreweryASP.Models.Dtos;
using OpenBreweryASP.Models.Entities;

namespace OpenBreweryASP.Contracts
{
    public interface IBreweryRepository
    {
        Task<IEnumerable<BreweryDto>> GetAllAsync();
        Task<BreweryDto> GetBreweryByCityAsync(string city);

        Task<BreweryDto> GetBreweryByStateAsync(string state);

        Task<BreweryDto> GetBreweryByTypeAsync(string type);
        Task<BreweryDto> CreateAsync(Brewery brewery);
        Task<bool> DeleteAsync(Guid id);
        Task<BreweryDto> UpdateAsync(Brewery brewery);
        Task<bool> ExistsByCityAsync(string city);
        
        Task<bool> ExistsByStateAsync(string state);

        Task<bool> ExistsByTypeAsync(string type);

        Task<bool> ExistsByIdAsync(Guid id);
    }
}