namespace Shop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12281 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "UserId");
        }
    }
}
