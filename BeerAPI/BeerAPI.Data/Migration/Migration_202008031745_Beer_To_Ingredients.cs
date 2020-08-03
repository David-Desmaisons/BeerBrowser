using FluentMigrator;

namespace BeerAPI.Data.Migration
{
    [Migration(202008031745)]
    public class Migration_202008031745_Beer_To_Ingredients : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("BeerIngredients")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("BeerId").AsInt32().NotNullable()
                .WithColumn("IngredientId").AsInt32().NotNullable();

            Create.ForeignKey().FromTable("BeerIngredients").ForeignColumn("BeerId").ToTable("Beer").PrimaryColumn("Id");
            Create.ForeignKey().FromTable("BeerIngredients").ForeignColumn("IngredientId").ToTable("Ingredient").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.Table("BeerIngredients");
        }
    }
}
