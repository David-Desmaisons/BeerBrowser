using FluentMigrator;

namespace BeerAPI.Data.Migration
{

    [Migration(202008031642)]
    public class Migration_202008031642_Ingredient : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("ingredient")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("name").AsString(50).NotNullable().Unique();
        }

        public override void Down()
        {
            Delete.Table("ingredient");
        }
    }
}
