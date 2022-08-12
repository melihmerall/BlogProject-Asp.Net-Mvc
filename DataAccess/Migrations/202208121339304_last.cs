namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.TagId);
            
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            AddColumn("dbo.Blogs", "BlogUrl", c => c.String());
            AddColumn("dbo.Blogs", "BlogClickCount", c => c.Int(nullable: false));
            AddColumn("dbo.Blogs", "BlogRating", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "ReplyCommentId", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "BlogRating", c => c.Int(nullable: false));
            DropColumn("dbo.Blogs", "BlogRate");
            DropColumn("dbo.Contacts", "MessageDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "MessageDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Blogs", "BlogRate", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "BlogRating");
            DropColumn("dbo.Comments", "ReplyCommentId");
            DropColumn("dbo.Blogs", "BlogRating");
            DropColumn("dbo.Blogs", "BlogClickCount");
            DropColumn("dbo.Blogs", "BlogUrl");
            DropColumn("dbo.Admins", "AdminRole");
            DropTable("dbo.Tags");
        }
    }
}
