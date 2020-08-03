using FluentMigrator;

namespace BeerAPI.Data.Migration
{

    [Migration(202008031642)]
    public class Migration_202008031642_Ingredient : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("Ingredient")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable().Unique();
        }

        public override void Down()
        {
            Delete.Table("Ingredient");
        }
    }
}
