namespace UWT.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasketUserProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("UWT.AspNetUsers", "Address", c => c.String());
            AlterColumn("UWT.Products", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("UWT.Products", "Tags", c => c.String(nullable: false));
            DropColumn("UWT.AspNetUsers", "Address");
        }
    }
}
