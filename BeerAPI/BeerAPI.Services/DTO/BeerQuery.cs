using System.ComponentModel.DataAnnotations;

namespace BeerAPI.Services.DTO
{
    public class BeerQuery
    {
        public string Name { get; set; }

        [Required]
        public Range Color { get; set; }

        [Required]
        public Range AlcoholPercentage { get; set; }

        [Required]
        public Range Temperature { get; set; }

        public int? IngredientId { get; set; }

        public int PageNumber { get; set; }
        public int MaxItems { get; set; }
    }
}
