namespace UWT.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackgroundMandatory : DbMigration
    {
        public override void Up()
        {
            DropIndex("UWT.PageStyles", new[] { "BackgroundImage_Id" });
            AlterColumn("UWT.PageStyles", "BackgroundImage_Id", c => c.Int());
            CreateIndex("UWT.PageStyles", "BackgroundImage_Id");
        }
        
        public override void Down()
        {
            DropIndex("UWT.PageStyles", new[] { "BackgroundImage_Id" });
            AlterColumn("UWT.PageStyles", "BackgroundImage_Id", c => c.Int(nullable: false));
            CreateIndex("UWT.PageStyles", "BackgroundImage_Id");
        }
    }
}
