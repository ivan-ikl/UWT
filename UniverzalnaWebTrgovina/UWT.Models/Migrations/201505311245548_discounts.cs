namespace UWT.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discounts : DbMigration
    {
        public override void Up()
        {
            AddColumn("UWT.Products", "Discount", c => c.Double(nullable: false));
            AddColumn("UWT.Categories", "Discount", c => c.Double(nullable: false));
            AddColumn("UWT.Shops", "Discount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("UWT.Shops", "Discount");
            DropColumn("UWT.Categories", "Discount");
            DropColumn("UWT.Products", "Discount");
        }
    }
}
