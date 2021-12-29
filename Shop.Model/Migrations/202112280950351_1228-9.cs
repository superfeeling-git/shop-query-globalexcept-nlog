namespace Shop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12289 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goods", "GoodsCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Goods", "GoodsCode");
        }
    }
}
