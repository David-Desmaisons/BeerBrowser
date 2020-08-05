using BeerAPI.Data.Entity;
using FluentNHibernate.Mapping;

namespace BeerAPI.Data.Mapping
{
    public class BeerMap : ClassMap<Beer>
    {
        public BeerMap()
        {
            Id(x => x.Id).Column("id").GeneratedBy.Sequence("beer_id_seq");

            Map(b => b.Name).Column("name").Length(50).Not.Nullable();
            Map(b => b.Description).Column("description").Length(500).Not.Nullable();
            Map(b => b.Harmonization).Column("harmonization").Length(500).Not.Nullable();

            Map(b => b.Color).Column("color").Not.Nullable();
            Map(b => b.AlcoholPercentage).Column("alcohol").Not.Nullable();
            Map(b => b.MinTemperature) .Column("mintemp").Not.Nullable();
            Map(b => b.MaxTemperature).Column("maxtemp").Not.Nullable();
            Map(b => b.Image).Column("picture").Not.Nullable();
            Map(b => b.PictureContentType).Column("contenttype").Not.Nullable();
            HasManyToMany(b => b.Ingredients)
                .Table("beeringredients")
                .ParentKeyColumn("beerid")
                .ChildKeyColumn("ingredientid").Cascade.SaveUpdate();

            Table("beer");
        }
    }
}
