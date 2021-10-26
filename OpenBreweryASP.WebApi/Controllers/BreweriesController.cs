using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenBreweryASP.Contracts;

namespace OpenBreweryASP.Controllers
{

    [Route("breweries")]
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
    }
}