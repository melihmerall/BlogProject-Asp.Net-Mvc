﻿namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentDate", c => c.DateTime(nullable: false));

        }

        public override void Down()
        {
            AddColumn("dbo.Comments", "CommentDate", c => c.DateTime(nullable: false));

        }
    }
}
