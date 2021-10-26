using Microsoft.AspNetCore.Mvc;

namespace OpenBreweryASP.Controllers
{
    public class SeedController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}