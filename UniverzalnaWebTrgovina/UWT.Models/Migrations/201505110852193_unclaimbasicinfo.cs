namespace UWT.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unclaimbasicinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("UWT.AspNetUsers", "Name", c => c.String(nullable: false));
            AddColumn("UWT.AspNetUsers", "Surname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("UWT.AspNetUsers", "Surname");
            DropColumn("UWT.AspNetUsers", "Name");
        }
    }
}
