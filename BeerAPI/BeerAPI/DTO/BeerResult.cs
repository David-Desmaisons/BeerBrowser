namespace BeerAPI.DTO
{
    public class BeerResult
    {
        public string Name { get; }
        public string Description { get; }
        public string Harmonization { get; }
        public string Color { get; }
        public decimal AlcoholPercentage { get; }
        public string Temperature { get; }
        public string Ingredients { get; }
        public string PictureUrl { get; }

        public BeerResult(string name, string description, string temperature, string pictureUrl, decimal alcoholPercentage, string harmonization, string color, string ingredients)
        {
            this.Description = description;
            this.PictureUrl = pictureUrl;
            this.AlcoholPercentage = alcoholPercentage;
            this.Harmonization = harmonization;
            this.Color = color;
            this.Ingredients = ingredients;
            this.Temperature = temperature;
            this.Name = name;
        }
    }
}
