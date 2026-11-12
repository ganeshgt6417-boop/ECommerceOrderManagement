
using ECommerceOrderManagement.API.DTOs;

namespace ECommerceOrderManagement.API.Services
{
    public interface IProductService
    {
        Task<List<ProductResponseDto>> GetAllProductsAsync();

        Task<ProductResponseDto?> GetProductByIdAsync(int id);

        Task<ProductResponseDto> CreateProductAsync(ProductCreateDto productDto);

        Task<bool> UpdateProductAsync(int id, ProductCreateDto productDto);

        Task<bool> DeleteProductAsync(int id);
    }
}
