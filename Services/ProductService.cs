
using ECommerceOrderManagement.API.DTOs;
using ECommerceOrderManagement.API.Models;
using ECommerceOrderManagement.API.Repositories;

namespace ECommerceOrderManagement.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllProductsAsync();

            return products.Select(p => new ProductResponseDto
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                Category = p.Category
            }).ToList();
        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);

            if (product == null)
                return null;

            return new ProductResponseDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = product.Category
            };
        }

        public async Task<ProductResponseDto> CreateProductAsync(ProductCreateDto productDto)
        {
            var product = new Product
            {
                ProductName = productDto.ProductName,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                Category = productDto.Category
            };

            var createdProduct = await _repository.AddProductAsync(product);

            return new ProductResponseDto
            {
                ProductId = createdProduct.ProductId,
                ProductName = createdProduct.ProductName,
                Description = createdProduct.Description,
                Price = createdProduct.Price,
                StockQuantity = createdProduct.StockQuantity,
                Category = createdProduct.Category
            };
        }

        public async Task<bool> UpdateProductAsync(int id, ProductCreateDto productDto)
        {
            var product = await _repository.GetProductByIdAsync(id);

            if (product == null)
                return false;

            product.ProductName = productDto.ProductName;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.StockQuantity = productDto.StockQuantity;
            product.Category = productDto.Category;

            return await _repository.UpdateProductAsync(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _repository.DeleteProductAsync(id);
        }
    }
}
