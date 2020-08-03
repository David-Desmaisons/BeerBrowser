using FluentMigrator;

namespace BeerAPI.Data.Migration
{
    [Migration(202008031736)]
    public class Migration_202008031736_Beer : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("Beer")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable().Unique()
                .WithColumn("Description").AsString(5000).NotNullable()
                .WithColumn("Harmonization").AsString(5000).NotNullable()
                .WithColumn("Color").AsDecimal().NotNullable()
                .WithColumn("AlcoholPercentage").AsDecimal().NotNullable()
                .WithColumn("MinTemperature").AsDecimal().NotNullable()
                .WithColumn("MaxTemperature").AsDecimal().NotNullable()
                .WithColumn("Picture").AsBinary().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Beer");
        }
    }
}
