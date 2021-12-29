namespace Shop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12286 : DbMigration
    {
        public override void Up()
        {
            /*DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "UserId" });
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "User_UserId");
            AlterColumn("dbo.Orders", "User_UserId", c => c.Guid());
            CreateIndex("dbo.Orders", "User_UserId");
            AddForeignKey("dbo.Orders", "User_UserId", "dbo.Users", "UserId");*/
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "User_UserId" });
            AlterColumn("dbo.Orders", "User_UserId", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Orders", name: "User_UserId", newName: "UserId");
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
