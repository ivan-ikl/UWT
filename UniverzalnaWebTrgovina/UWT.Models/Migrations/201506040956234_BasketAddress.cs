namespace UWT.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasketAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("UWT.Baskets", "DeliveryPerson", c => c.String());
            AddColumn("UWT.Baskets", "DeliveryAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("UWT.Baskets", "DeliveryAddress");
            DropColumn("UWT.Baskets", "DeliveryPerson");
        }
    }
}
