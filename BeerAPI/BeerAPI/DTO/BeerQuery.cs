namespace BeerAPI.DTO
{
    public class BeerQuery
    {
        public string Name { get; set; }
        public Range Color { get; set; }
        public Range AlcoholPercentage { get; set; }
        public Range Temperature { get; set; }
        public string Ingredient { get; set; }
        public int PageNumber { get; set; }
        public int MaxItems { get; set; }
    }
}
