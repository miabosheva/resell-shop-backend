using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace backend_resell_app.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {

        private readonly ApplicationDbContext db;

        public CityController(ApplicationDbContext db) {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = this.db.Cities.ToListAsync(); 
            return Ok(cities);
        }

    }
}
