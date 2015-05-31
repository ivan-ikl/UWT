namespace UWT.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discounts2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("UWT.BasketItems", "DiscountedFrom", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("UWT.BasketItems", "DiscountedFrom");
        }
    }
}
