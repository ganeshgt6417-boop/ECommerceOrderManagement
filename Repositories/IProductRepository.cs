
using ECommerceOrderManagement.API.Models;

namespace ECommerceOrderManagement.API.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();

        Task<Product?> GetProductByIdAsync(int id);

        Task<Product> AddProductAsync(Product product);

        Task<bool> UpdateProductAsync(Product product);

        Task<bool> DeleteProductAsync(int id);
    }
}
