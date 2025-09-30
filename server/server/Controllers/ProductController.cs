using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Entities;
using server.Interface.Repository;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<ResponseDto>> GetAllProducts()
        {
            ResponseDto response = new ResponseDto();
            IEnumerable<Product> products = await productRepository.GetAllAsync();
            response.Data = products;
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetProducts(int productId)
        {
            ResponseDto response = new ResponseDto();
            Product product = await productRepository.GetByIdAsync(productId);
            response.Data = product;
            return Ok(response);
        }



        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> createProducts(Product newProduct)
        {
            await productRepository.AddAsync(newProduct);
            return Created();
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult> updateProducts(Product product)
        {
            await productRepository.UpdateAsync(product);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{productId}")]
        public async Task<ActionResult> deleteProducts(int productId)
        {
            ResponseDto response = new ResponseDto();
            Product product = await productRepository.GetByIdAsync(productId);

            if (product == null)
            {
                response.IsSuccessed = false;
                response.Message = $"No Product found with id {productId.ToString()}";
                return BadRequest(response);
            }
            await productRepository.DeleteAsync(product);
            return Ok();

        }

    }
}
