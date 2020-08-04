using FluentMigrator;

namespace BeerAPI.Data.Migration
{
    [Migration(202008031745)]
    public class Migration_202008031745_Beer_To_Ingredients : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("beer-ingredients")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("beer-id").AsInt32().NotNullable()
                .WithColumn("ingredient-id").AsInt32().NotNullable();

            Create.ForeignKey().FromTable("beer-ingredients").ForeignColumn("beer-id").ToTable("beer").PrimaryColumn("id");
            Create.ForeignKey().FromTable("beer-ingredients").ForeignColumn("ingredient-id").ToTable("ingredient").PrimaryColumn("id");
        }

        public override void Down()
        {
            Delete.Table("beer-ingredients");
        }
    }
}
