namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogRating", c => c.Int(nullable: false));
            DropColumn("dbo.Blogs", "BlogRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "BlogRate", c => c.Int(nullable: false));
            DropColumn("dbo.Blogs", "BlogRating");
        }
    }
}
