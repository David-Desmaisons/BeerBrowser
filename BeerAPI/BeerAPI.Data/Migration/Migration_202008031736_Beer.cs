using FluentMigrator;

namespace BeerAPI.Data.Migration
{
    [Migration(202008031736)]
    public class Migration_202008031736_Beer : FluentMigrator.Migration
    {
        public override void Up()
        {

            Execute.Sql(@"CREATE TABLE public.beer
            (
                id SERIAL PRIMARY KEY,
                name character varying(50) COLLATE pg_catalog.""default"" NOT NULL,
                description character varying(5000) COLLATE pg_catalog.""default"" NOT NULL,
                harmonization character varying(5000) COLLATE pg_catalog.""default"" NOT NULL,
                color numeric(19, 5) NOT NULL,
                alcohol numeric(19, 5) NOT NULL,
                mintemp numeric(19, 5) NOT NULL,
                maxtemp numeric(19, 5) NOT NULL,
                picture bytea NOT NULL,
                contenttype character varying(20) COLLATE pg_catalog.""default"" NOT NULL
            )");
        }

        public override void Down()
        {
            Delete.Table("beer");
        }
    }
}
