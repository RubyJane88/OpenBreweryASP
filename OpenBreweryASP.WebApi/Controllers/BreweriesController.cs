using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenBreweryASP.Contracts;
using OpenBreweryASP.Models.Entities;

namespace OpenBreweryASP.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class BreweriesController : ControllerBase
    {
        private readonly IBreweryRepository _repo;

        public BreweriesController(IBreweryRepository repo)
        {
            _repo = repo;
        }
        
        
        
        
        //GET: breweries/
        [HttpGet]
        public async Task<IActionResult> GetAllBreweries([FromQuery(Name = "by_city")] string city)
        {
            //IF NO CITY, RETURN ALL BREWERIES
            if (string.IsNullOrEmpty(city))
            {
                var brewery = await _repo.GetAllBreweriesAsync();
                var response = Ok(brewery);
                return response;
            }
            else
            {
                //IF CITY, RETURN BREWERIES WITH CITY
                var brewery = await _repo.GetBreweryByCityAsync(city);
                if (brewery == null)
                    return NotFound();
                var response = Ok(brewery);
                return response;
            }
        }

        
        
        //GET: by_state
        [HttpGet("by_state")]
        public async Task<IActionResult> GetBreweriesByState([FromQuery(Name = "by_state")] string state)
        {
            var brewery = await _repo.GetBreweriesByStateAsync(state);
                if (string.IsNullOrEmpty(state))
                    return NotFound();
                
                var response = Ok(brewery);
                return response;
                
        }
        
        //GET: by_type
        [HttpGet("by_type")]
        public async Task<IActionResult> GetBreweriesByType([FromQuery(Name = "by_type")] string type)
        {
            var brewery = await _repo.GetBreweriesByTypeAsync(type);
            if (string.IsNullOrEmpty(type))
                return NotFound();
            
            var response = Ok(brewery);
            return response;
        }

        //DELETE: /{id:guid}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBrewery(Guid id)
        {
            
            var isSuccess =  await _repo.DeleteBreweryAsync(id);
            //return notFound if trying to delete
            //an item that doesn't exists
            return isSuccess ? Ok() : NotFound();
        }
        
        //POST: /breweries
        [HttpPost]
        public async Task<IActionResult> PostBrewery(Brewery brewery)
        {
            var breweryDto = await _repo.CreateBreweryAsync(brewery);
            var response = Ok(breweryDto);

            return response;
        }
        
        //PUT: /breweries/{id:guid}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutBrewery(Guid id, Brewery brewery)
        {
            if (id != brewery.Id)
                return BadRequest();

            await _repo.UpdateBreweryAsync(brewery);
            return NoContent();
        }


    }
}