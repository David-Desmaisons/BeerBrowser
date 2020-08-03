namespace BeerAPI.DTO
{
    public class BeerResult
    {
        public string Name { get; }
        public string Description { get; }
        public string Harmonization { get; }
        public int Color { get; }
        public decimal AlcoholPercentage { get; }
        public Range Temperature { get; }
        public string[]  Ingredients{ get; }
        public string PictureUrl { get; }
        public int Id { get; }

        public BeerResult(int id, string name, string description, Range temperature, string pictureUrl, decimal alcoholPercentage, string harmonization, int color, string[] ingredients)
        {
            this.Description = description;
            this.PictureUrl = pictureUrl;
            this.AlcoholPercentage = alcoholPercentage;
            this.Harmonization = harmonization;
            this.Color = color;
            this.Ingredients = ingredients;
            this.Id = id;
            this.Temperature = temperature;
            this.Name = name;
        }
    }
}
