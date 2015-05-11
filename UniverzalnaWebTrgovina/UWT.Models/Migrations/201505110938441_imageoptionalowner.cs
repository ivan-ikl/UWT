namespace UWT.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageoptionalowner : DbMigration
    {
        public override void Up()
        {
            DropIndex("UWT.Images", new[] { "Owner_Id" });
            AlterColumn("UWT.Images", "Owner_Id", c => c.String(maxLength: 128));
            CreateIndex("UWT.Images", "Owner_Id");
        }
        
        public override void Down()
        {
            DropIndex("UWT.Images", new[] { "Owner_Id" });
            AlterColumn("UWT.Images", "Owner_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("UWT.Images", "Owner_Id");
        }
    }
}
