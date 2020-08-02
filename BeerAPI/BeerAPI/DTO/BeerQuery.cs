using BeerAPI.Infra;
using Microsoft.AspNetCore.Mvc;

namespace BeerAPI.DTO
{
    public class BeerQuery
    {
        public string Name { get; set; }

        [ModelBinder(BinderType = typeof(RangeModelBinder))]
        public Range Color { get; set; }

        [ModelBinder(BinderType = typeof(RangeModelBinder))]
        public Range AlcoholPercentage { get; set; }

        [ModelBinder(BinderType = typeof(RangeModelBinder))]
        public Range Temperature { get; set; }

        public int? IngredientId { get; set; }

        public int PageNumber { get; set; }
        public int MaxItems { get; set; }
    }
}
