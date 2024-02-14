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
        private IMapper mapper;
        public ProductController(IUnitOfWork uow, IMapper mapper) {
            this.unitOfWork = uow;
            this.mapper = mapper;
        }

        //product/list/miabosheva
        [HttpGet("list/{username}")]
        public async Task<IActionResult> GetProductsListByUsername(string username)
        {
            int id = unitOfWork.UserRepository.returnIdByUsername(username);
            var products = await unitOfWork.ProductRepository.GetProductAsync(id);
            var productListDto = mapper.Map<IEnumerable<ProductListDto>>(products);
            return Ok(productListDto);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllProductsList()
        {
            var products = await unitOfWork.ProductRepository.GetAllProductsAsync();
            var productListDto = mapper.Map<IEnumerable<ProductListDto>>(products);
            return Ok(productListDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductListDto productList)
        {
            var conditionType = unitOfWork.ProductRepository.GetConditionTypeObjectFromName(productList.ConditionType).Result;
            var productType = unitOfWork.ProductRepository.GetTypeObjectFromName(productList.ProductType).Result;
            var userId = unitOfWork.UserRepository.returnIdByUsername(productList.Username);

            var addedProduct = await unitOfWork.ProductRepository.AddProduct(productList, userId, conditionType, productType);
            return Ok(addedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deletedProduct = await unitOfWork.ProductRepository.DeleteProduct(id);
            return Ok(deletedProduct);
        }
    }
}
