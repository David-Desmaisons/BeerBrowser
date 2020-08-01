namespace BeerAPI.DTO
{
    public class BeerResultBuilder
    {
        private string _Name;
        private string _Description;
        private string _Harmonization;
        private string _Color;
        private decimal _AlcoholPercentage;
        private string _Temperature;
        private string _Ingredients;
        private string _PictureUrl;

        public BeerResultBuilder SetName(string value)
        {
            _Name = value;
            return this;
        }

        public BeerResultBuilder SetDescription(string value)
        {
            _Description = value;
            return this;
        }

        public BeerResultBuilder SetColor(string value)
        {
            _Color = value;
            return this;
        }

        public BeerResultBuilder SetHarmonization(string value)
        {
            _Harmonization = value;
            return this;
        }

        public BeerResultBuilder SetTemperature(string value)
        {
            _Temperature = value;
            return this;
        }

        public BeerResultBuilder SetIngredients(string value)
        {
            _Ingredients = value;
            return this;
        }

        public BeerResultBuilder SetAlcoholPercentage(decimal value)
        {
            _AlcoholPercentage = value;
            return this;
        }

        public BeerResultBuilder SetPictureUrl(string value)
        {
            _PictureUrl = value;
            return this;
        }

        public BeerResult Build()
        {
            return new BeerResult(_Name, _Description, _Temperature, _PictureUrl, _AlcoholPercentage, _Harmonization, _Color, _Ingredients);
        }
    }
}
