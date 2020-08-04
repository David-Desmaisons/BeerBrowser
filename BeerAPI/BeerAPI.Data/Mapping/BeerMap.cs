using BeerAPI.Data.Entity;
using FluentNHibernate.Mapping;

namespace BeerAPI.Data.Mapping
{
    public class BeerMap : ClassMap<Beer>
    {
        public BeerMap()
        {
            Id(x => x.Id).Column("id");

            Map(b => b.Name).Column("name").Length(50).Not.Nullable();
            Map(b => b.Description).Column("description").Length(500).Not.Nullable();
            Map(b => b.Harmonization).Column("harmonization").Length(500).Not.Nullable();

            Map(b => b.Color).Column("color").Not.Nullable();
            Map(b => b.AlcoholPercentage).Column("alcohol-percentage").Not.Nullable();
            Map(b => b.MinTemperature) .Column("min-temperature").Not.Nullable();
            Map(b => b.MaxTemperature).Column("max-temperature").Not.Nullable();
            Map(b => b.Image).Column("picture").Not.Nullable();
            HasManyToMany(b => b.Ingredients)
                .Table("beer-ingredients")
                .ParentKeyColumn("beer-id")
                .ChildKeyColumn("ingredient-id");

            Table("beer");
        }
    }
}
