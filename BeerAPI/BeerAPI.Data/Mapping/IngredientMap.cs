using BeerAPI.Data.Entity;
using FluentNHibernate.Mapping;

namespace BeerAPI.Data.Mapping
{
    public class IngredientMap : ClassMap<Ingredient>
    {
        public IngredientMap()
        {
            Id(x => x.Id).Column("id").GeneratedBy.Sequence("ingredient_id_seq");

            Map(b => b.Name).Column("name").Length(50).Not.Nullable();

            Table("ingredient");
        }
    }
}
