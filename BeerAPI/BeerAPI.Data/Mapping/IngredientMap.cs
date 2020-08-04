using BeerAPI.Data.Entity;
using FluentNHibernate.Mapping;

namespace BeerAPI.Data.Mapping
{
    public class IngredientMap : ClassMap<Ingredient>
    {
        public IngredientMap()
        {
            Id(x => x.Id).Column("id");

            Map(b => b.Name).Column("name").Length(50).Not.Nullable();

            Table("ingredient");
        }
    }
}
