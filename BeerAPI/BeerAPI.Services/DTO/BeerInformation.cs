namespace BeerAPI.Services.DTO
{
    public class BeerInformation
    {
        public BeerInformation(string name, string description, string harmonization, int color, decimal alcoholPercentage, Range temperature, string[] ingredients, byte[] picture, string pictureContentType)
        {
            Name = name;
            Description = description;
            Harmonization = harmonization;
            Color = color;
            AlcoholPercentage = alcoholPercentage;
            Temperature = temperature;
            Ingredients = ingredients;
            Picture = picture;
            PictureContentType = pictureContentType;
        }

        public string Name { get; }
        public string Description { get; }
        public string Harmonization { get; }
        public int Color { get;  }
        public decimal AlcoholPercentage { get;  }
        public Range Temperature { get;  }
        public string[] Ingredients { get;  }
        public byte[] Picture { get; }
        public string PictureContentType { get; }



        //Name = Name,
        //AlcoholPercentage = AlcoholPercentage,
        //Color = Color,
        //Description = Description,
        //Harmonization = Harmonization,
        //Ingredients = Ingredients,
        //Temperature = Temperature,
        //Picture = data,
        //PictureContentType = Picture.ContentType
    }
}
