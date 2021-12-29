namespace Shop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12283 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "User_UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "User_UserId" });
            DropColumn("dbo.Orders", "UserId");
            RenameColumn(table: "dbo.Orders", name: "User_UserId", newName: "UserId");
            AlterColumn("dbo.Orders", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Orders", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "UserId" });
            AlterColumn("dbo.Orders", "UserId", c => c.Guid());
            AlterColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "User_UserId");
            AddColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "User_UserId");
            AddForeignKey("dbo.Orders", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
