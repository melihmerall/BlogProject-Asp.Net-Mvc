namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "AuthorTwitter", c => c.String());
            AddColumn("dbo.Authors", "AuthorInstagram", c => c.String());
            AddColumn("dbo.Authors", "AuthorLinkedin", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "AuthorLinkedin");
            DropColumn("dbo.Authors", "AuthorInstagram");
            DropColumn("dbo.Authors", "AuthorTwitter");
        }
    }
}
