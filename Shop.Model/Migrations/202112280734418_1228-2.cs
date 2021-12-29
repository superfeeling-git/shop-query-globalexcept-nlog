namespace Shop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12282 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Orders", "User_UserId", c => c.Guid());
            CreateIndex("dbo.Orders", "User_UserId");
            AddForeignKey("dbo.Orders", "User_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "User_UserId" });
            DropColumn("dbo.Orders", "User_UserId");
            DropTable("dbo.Users");
        }
    }
}
