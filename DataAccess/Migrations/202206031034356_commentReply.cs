namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentReply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ReplyCommentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "ReplyCommentId");
        }
    }
}
