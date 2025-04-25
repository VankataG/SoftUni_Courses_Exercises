using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ProductShop.DTOs
{
    public class CategoryDto
    {
        [Required] 
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
    }
}
