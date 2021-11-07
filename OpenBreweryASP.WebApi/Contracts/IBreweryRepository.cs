using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenBreweryASP.Models.Dtos;
using OpenBreweryASP.Models.Entities;

namespace OpenBreweryASP.Contracts
{
    public interface IBreweryRepository
    {
        Task<IEnumerable<BreweryDto>> GetAllBreweriesAsync();
        Task<IEnumerable<BreweryDto>> GetBreweryByCityAsync(string city);

        Task <IEnumerable<BreweryDto>> GetBreweriesByStateAsync(string state);

        Task <IEnumerable<BreweryDto>> GetBreweriesByTypeAsync(string type);
        Task<BreweryDto> CreateBreweryAsync(Brewery brewery);
        Task<bool> DeleteBreweryAsync(Guid id);
        Task<BreweryDto> UpdateBreweryAsync(Brewery brewery);
        Task<bool> ExistsByCityAsync(string city);
        
        Task<bool> ExistsByStateAsync(string state);

        Task<bool> ExistsByTypeAsync(string type);

        Task<bool> ExistsByIdAsync(Guid id);

    }
}