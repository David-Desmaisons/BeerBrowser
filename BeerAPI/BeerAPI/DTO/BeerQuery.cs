namespace BeerAPI.DTO
{
    public class BeerQuery
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal AlcoholPercentage { get; set; }
        public string Temperature { get; set; }
        public string Ingredients { get; set; }
    }
}
