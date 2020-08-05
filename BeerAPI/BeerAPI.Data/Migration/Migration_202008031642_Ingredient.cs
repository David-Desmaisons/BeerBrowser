using FluentMigrator;

namespace BeerAPI.Data.Migration
{

    [Migration(202008031642)]
    public class Migration_202008031642_Ingredient : FluentMigrator.Migration
    {
        public override void Up()
        {
            Execute.Sql(@"CREATE TABLE public.ingredient
            (
                id SERIAL PRIMARY KEY,
                name character varying(50) COLLATE pg_catalog.""default"" NOT NULL
            )");
        }

        public override void Down()
        {
            Delete.Table("ingredient");
        }
    }
}
