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
        Task<BreweryDto> CreateAsync(Brewery brewery);
        Task DeleteAsync(int id);
        Task<BreweryDto> UpdateAsync(Brewery brewery);
        Task<bool> ExistsByCityAsync(string city);
    }
}