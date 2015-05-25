namespace UWT.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserBlocked : DbMigration
    {
        public override void Up()
        {
            AddColumn("UWT.AspNetUsers", "Blocked", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("UWT.AspNetUsers", "Blocked");
        }
    }
}
