using AutoMapper;
using backend_resell_app.Data.Dto;
using backend_resell_app.Data.Repository;
using backend_resell_app.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend_resell_app.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IUnitOfWork unitOfWork; 
        private readonly IUserRepository userRepository;
        private IMapper mapper;
        public ProductController(IUnitOfWork uow, IUserRepository userRepository, IMapper mapper) {
            this.unitOfWork = uow;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        //product/type/miabosheva
        [HttpGet("type/{username}")]
        public async Task<IActionResult> GetPropertyList(string username)
        {
            int id = userRepository.returnIdByUsername(username);
            var products = await unitOfWork.ProductRepository.GetProductAsync(id);
            var productListDto = mapper.Map<IEnumerable<ProductListDto>>(products);
            return Ok(productListDto);
        }
    }
}
