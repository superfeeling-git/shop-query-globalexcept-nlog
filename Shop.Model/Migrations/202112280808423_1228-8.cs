namespace Shop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12288 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "User_UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "User_UserId" });
            RenameColumn(table: "dbo.Orders", name: "User_UserId", newName: "UserId");
            AlterColumn("dbo.Orders", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "UserId" });
            AlterColumn("dbo.Orders", "UserId", c => c.Guid());
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "User_UserId");
            CreateIndex("dbo.Orders", "User_UserId");
            AddForeignKey("dbo.Orders", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
