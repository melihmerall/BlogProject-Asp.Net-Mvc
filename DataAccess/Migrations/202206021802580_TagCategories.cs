namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagCategories : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TagCategories", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.TagCategories", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.TagCategories", new[] { "Tag_TagId" });
            DropIndex("dbo.TagCategories", new[] { "Category_CategoryId" });
            DropTable("dbo.TagCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagCategories",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Category_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Category_CategoryId });
            
            CreateIndex("dbo.TagCategories", "Category_CategoryId");
            CreateIndex("dbo.TagCategories", "Tag_TagId");
            AddForeignKey("dbo.TagCategories", "Category_CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.TagCategories", "Tag_TagId", "dbo.Tags", "TagId", cascadeDelete: true);
        }
    }
}
