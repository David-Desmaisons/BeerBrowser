using FluentMigrator;

namespace BeerAPI.Data.Migration
{
    [Migration(202008031745)]
    public class Migration_202008031745_Beer_To_Ingredients : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("beeringredients")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("beerid").AsInt32().NotNullable()
                .WithColumn("ingredientid").AsInt32().NotNullable();

            Create.ForeignKey().FromTable("beeringredients").ForeignColumn("beerid").ToTable("beer").PrimaryColumn("id");
            Create.ForeignKey().FromTable("beeringredients").ForeignColumn("ingredientid").ToTable("ingredient").PrimaryColumn("id");
        }

        public override void Down()
        {
            Delete.Table("beeringredients");
        }
    }
}
