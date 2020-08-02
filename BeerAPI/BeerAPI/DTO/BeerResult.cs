namespace BeerAPI.DTO
{
    public class BeerResult
    {
        public string Name { get; }
        public string Description { get; }
        public string Harmonization { get; }
        public int Color { get; }
        public decimal AlcoholPercentage { get; }
        public int MinTemperature { get; }
        public int MaxTemperature { get; }
        public string Ingredients { get; }
        public string PictureUrl { get; }
        public int Id { get; }

        public BeerResult(int id, string name, string description, int minTemperature, int maxTemperature, string pictureUrl, decimal alcoholPercentage, string harmonization, int color, string ingredients)
        {
            this.Description = description;
            this.PictureUrl = pictureUrl;
            this.AlcoholPercentage = alcoholPercentage;
            this.Harmonization = harmonization;
            this.Color = color;
            this.Ingredients = ingredients;
            this.Id = id;
            this.MinTemperature = minTemperature;
            this.MaxTemperature = maxTemperature;
            this.Name = name;
        }
    }
}
