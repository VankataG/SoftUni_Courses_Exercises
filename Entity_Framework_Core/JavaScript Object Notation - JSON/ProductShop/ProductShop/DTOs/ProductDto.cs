using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ProductShop.DTOs
{
    public class ProductDto
    {
        [Required]
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [Required]
        [JsonProperty(nameof(Price))]
        public string Price { get; set; }

        [Required]
        [JsonProperty(nameof(SellerId))]
        public string SellerId { get; set; }

        [JsonProperty(nameof(BuyerId))]
        public string? BuyerId { get; set; }
    }
}
