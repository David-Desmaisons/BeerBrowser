using FluentMigrator;

namespace BeerAPI.Data.Migration
{
    [Migration(202008031736)]
    public class Migration_202008031736_Beer : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("beer")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("name").AsString(50).NotNullable().Unique()
                .WithColumn("description").AsString(5000).NotNullable()
                .WithColumn("harmonization").AsString(5000).NotNullable()
                .WithColumn("color").AsDecimal().NotNullable()
                .WithColumn("alcohol-percentage").AsDecimal().NotNullable()
                .WithColumn("min-temperature").AsDecimal().NotNullable()
                .WithColumn("max-temperature").AsDecimal().NotNullable()
                .WithColumn("picture").AsBinary().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("beer");
        }
    }
}
