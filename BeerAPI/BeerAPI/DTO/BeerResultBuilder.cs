namespace BeerAPI.DTO
{
    public class BeerResultBuilder
    {
        private int _Id;
        private string _Name;
        private string _Description;
        private string _Harmonization;
        private int _Color;
        private decimal _AlcoholPercentage;
        private int _MinTemperature;
        private int _MaxTemperature;
        private string _Ingredients;
        private string _PictureUrl;

        public BeerResultBuilder SetId(int value)
        {
            _Id = value;
            return this;
        }

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

        public BeerResultBuilder SetColor(int value)
        {
            _Color = value;
            return this;
        }

        public BeerResultBuilder SetHarmonization(string value)
        {
            _Harmonization = value;
            return this;
        }

        public BeerResultBuilder SetMaxTemperature(int value)
        {
            _MaxTemperature = value;
            return this;
        }

        public BeerResultBuilder SetMinTemperature(int value)
        {
            _MinTemperature = value;
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
            return new BeerResult(_Id, _Name, _Description, _MinTemperature, _MaxTemperature, _PictureUrl, _AlcoholPercentage, _Harmonization, _Color, _Ingredients);
        }
    }
}
