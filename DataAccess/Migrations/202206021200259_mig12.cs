namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "Tags");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Tags", c => c.String(maxLength: 30));
        }
    }
}
