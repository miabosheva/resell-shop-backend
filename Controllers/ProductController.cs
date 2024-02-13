using backend_resell_app.Data.Repository;
using backend_resell_app.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend_resell_app.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IUnitOfWork unitOfWork; 
        private readonly IUserRepository userRepository;
        public ProductController(IUnitOfWork uow, IUserRepository userRepository) {
            this.unitOfWork = uow;
            this.userRepository = userRepository;
        }

        //product/type/miabosheva
        [HttpGet("type/{username}")]
        public async Task<IActionResult> GetPropertyList(string username)
        {
            int id = userRepository.returnIdByUsername(username);
            var products = await unitOfWork.ProductRepository.GetProductAsync(id);
            return Ok(products);
        }
    }
}
