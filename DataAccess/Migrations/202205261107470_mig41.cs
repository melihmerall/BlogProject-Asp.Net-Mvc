namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig41 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "AuthorTitle", c => c.String(maxLength: 50));
            AddColumn("dbo.Authors", "AuthorShortAbout", c => c.String(maxLength: 100));
            AddColumn("dbo.Authors", "AuthorMail", c => c.String(maxLength: 50));
            AddColumn("dbo.Authors", "AuthorPassword", c => c.String(maxLength: 16));
            AddColumn("dbo.Authors", "AuthorPhone", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "AuthorPhone");
            DropColumn("dbo.Authors", "AuthorPassword");
            DropColumn("dbo.Authors", "AuthorMail");
            DropColumn("dbo.Authors", "AuthorShortAbout");
            DropColumn("dbo.Authors", "AuthorTitle");
        }
    }
}
