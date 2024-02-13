using backend_resell_app.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace backend_resell_app.Data
{
    public class CityController : BaseController
    {

        private readonly ApplicationDbContext db;

        public CityController(ApplicationDbContext db) {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await this.db.Cities.ToListAsync(); 
            return Ok(cities);
        }

    }
}
