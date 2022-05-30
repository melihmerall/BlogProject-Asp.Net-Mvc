namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Authors", "AuthorStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Blogs", "BlogStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "CategoryStatus", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryStatus");
            DropColumn("dbo.Blogs", "BlogStatus");
            DropColumn("dbo.Authors", "AuthorStatus");
            DropColumn("dbo.Admins", "AdminStatus");
        }
    }
}
