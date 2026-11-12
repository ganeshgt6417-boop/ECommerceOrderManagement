
using ECommerceOrderManagement.API.DTOs;
using ECommerceOrderManagement.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceOrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();

            return Ok(products);
        }

        // GET: api/Products/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateDto productDto)
        {
            var product = await _productService.CreateProductAsync(productDto);

            return CreatedAtAction(
                nameof(GetProductById),
                new { id = product.ProductId },
                product);
        }

        // PUT: api/Products/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductCreateDto productDto)
        {
            var result = await _productService.UpdateProductAsync(id, productDto);

            if (!result)
                return NotFound("Product not found");

            return NoContent();
        }

        // DELETE: api/Products/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);

            if (!result)
                return NotFound("Product not found");

            return NoContent();
        }
       
    }
}
