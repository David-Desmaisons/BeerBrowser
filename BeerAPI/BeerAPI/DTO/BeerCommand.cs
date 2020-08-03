using BeerAPI.Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerAPI.DTO
{
    public class BeerCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Harmonization { get; set; }
        public int Color { get; set; }
        public decimal AlcoholPercentage { get; set; }
        [ModelBinder(BinderType = typeof(RangeModelBinder))]
        public Range Temperature { get; set; }
        [ModelBinder(BinderType = typeof(ArrayStringModelBinder))]
        public string[] Ingredients { get; set; }
        public IFormFile Picture { get; set; }
    }
}
