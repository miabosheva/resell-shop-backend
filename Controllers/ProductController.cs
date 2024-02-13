using backend_resell_app.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend_resell_app.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IUnitOfWork unitOfWork; 
        public ProductController(IUnitOfWork uow) {
            this.unitOfWork = uow;
        }

        //product/type/miabosheva
        [HttpGet("type/{username}")]
        public async Task<IActionResult> GetPropertyList(string username)
        {
            var products = await unitOfWork.ProductRepository.GetProductAsync(username);
            return Ok(products);
        }
    }
}
