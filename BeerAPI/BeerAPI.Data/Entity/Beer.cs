using System.Collections.Generic;

namespace BeerAPI.Data.Entity
{
    public class Beer
    {
        public virtual int? Id { get; set; }
        public virtual string Name { get; set;  }
        public virtual string Description { get; set; }
        public virtual string Harmonization { get; set; }
        public virtual int Color { get; set; }
        public virtual decimal AlcoholPercentage { get; set; }
        public virtual int MinTemperature { get; set; }
        public virtual int MaxTemperature { get; set; }
        public virtual IList<Ingredient> Ingredients { get; set; }
        public virtual byte[] Image { get; set; }
    }
}
