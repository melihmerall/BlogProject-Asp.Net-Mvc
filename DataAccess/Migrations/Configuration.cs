namespace DataAccess.Migrations
{
    using Entity.Concrete;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Concrete.EntityFramework.Contexts.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAccess.Concrete.EntityFramework.Contexts.BlogContext context)
        {

        }
    }
}
