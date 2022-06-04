namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagBlog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagBlogs",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Blog_BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Blog_BlogId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Blogs", t => t.Blog_BlogId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Blog_BlogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagBlogs", "Blog_BlogId", "dbo.Blogs");
            DropForeignKey("dbo.TagBlogs", "Tag_TagId", "dbo.Tags");
            DropIndex("dbo.TagBlogs", new[] { "Blog_BlogId" });
            DropIndex("dbo.TagBlogs", new[] { "Tag_TagId" });
            DropTable("dbo.TagBlogs");
        }
    }
}
