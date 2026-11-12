using System.ComponentModel.DataAnnotations;

namespace ECommerceOrderManagement.API.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Range(0.01, 100000)]
        public decimal Price { get; set; }

        [Range(0, 100000)]
        public int StockQuantity { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;
    }
}