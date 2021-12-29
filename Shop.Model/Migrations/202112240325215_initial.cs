namespace Shop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        GoodsId = c.Int(nullable: false, identity: true),
                        GoodsName = c.String(),
                        GoodsPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GoodsId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderCode = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        OrderState = c.Int(nullable: false),
                        ReceiveName = c.String(),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.OrderGoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GoodsId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goods", t => t.GoodsId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.GoodsId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderGoods", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderGoods", "GoodsId", "dbo.Goods");
            DropIndex("dbo.OrderGoods", new[] { "OrderId" });
            DropIndex("dbo.OrderGoods", new[] { "GoodsId" });
            DropTable("dbo.OrderGoods");
            DropTable("dbo.Orders");
            DropTable("dbo.Goods");
        }
    }
}
