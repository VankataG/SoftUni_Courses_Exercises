using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ProductShop.DTOs
{
    public class CategoryProductDto
    {
        [Required]
        [JsonProperty(nameof(CategoryId))]
        public string CategoryId { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(ProductId))]
        public string ProductId { get; set; } = null!;
    }
}
