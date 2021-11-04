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
        public async Task<IActionResult> GetBreweries([FromQuery(Name = "by_city")] string city)
        {
            if ( city == null)
            {
                var brewery = await _repo.GetAllAsync();
                var response = Ok(brewery);
                return response;
            }
            else
            {
                var brewery = await _repo.GetBreweryByCityAsync(city);
                if (brewery == null)
                    return NotFound();
                var response = Ok(brewery);
                return response;
            }
        }

        //GET: by_state
        [HttpGet("by_state")]
        public async Task<IActionResult> GetBreweryByState([FromQuery(Name = "by_state")] string state)
        {
            var brewery = await _repo.GetBreweryByStateAsync(state);
                if (brewery == null)
                    return NotFound();
                var response = Ok(brewery);
                return response;
                
        }
        
        //GET: by_type
        [HttpGet("/by_type")]
        public async Task<IActionResult> GetBreweryByType([FromQuery(Name = "by_type")] string type)
        {
            var brewery = await _repo.GetBreweryByTypeAsync(type);
            if (brewery == null) return NotFound();
            var response = Ok(brewery);
            return response;
        }

        //DELETE: /{id:guid}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBrewery(Guid id)
        {
            
            var isSuccess =  await _repo.DeleteAsync(id);
            //return notFound if trying to delete
            //an item that doesn't exists
            return isSuccess ? Ok() : NotFound();
        }
        
        //POST: /breweries
        [HttpPost]
        public async Task<IActionResult> PostBrewery(Brewery brewery)
        {
            var breweryDto = await _repo.CreateAsync(brewery);
            var response = Ok(breweryDto);

            return response;
        }
        
        //PUT: /breweries/{id:guid}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutTodo(Guid id, Brewery brewery)
        {
            if (id != brewery.Id)
                return BadRequest();

            await _repo.UpdateAsync(brewery);
            return NoContent();
        }


    }
}