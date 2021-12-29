namespace Shop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _122810 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderGoods", "BuyCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderGoods", "BuyCount");
        }
    }
}
