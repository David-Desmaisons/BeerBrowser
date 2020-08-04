using System.ComponentModel.DataAnnotations;
using BeerAPI.Infra;
using Microsoft.AspNetCore.Mvc;

namespace BeerAPI.DTO
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
