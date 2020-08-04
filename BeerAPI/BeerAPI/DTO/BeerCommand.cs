using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BeerAPI.DTO
{
    public class BeerCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Harmonization { get; set; }
        public int Color { get; set; }
        public decimal AlcoholPercentage { get; set; }
        [Required]
        public Range Temperature { get; set; }
        [Required]
        public string[] Ingredients { get; set; }
        public IFormFile Picture { get; set; }
    }
}
