namespace UWT.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shopstyle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("UWT.PageStyles", "PageLayout_Id", "UWT.PageLayouts");
            DropForeignKey("UWT.Categories", "Id", "UWT.Images");
            DropForeignKey("UWT.CategoryProducts", "Category_Id", "UWT.Categories");
            DropIndex("UWT.Categories", new[] { "Id" });
            DropIndex("UWT.PageStyles", new[] { "PageLayout_Id" });
            DropPrimaryKey("UWT.Categories");
            AddColumn("UWT.Categories", "Image_Id", c => c.Long(nullable: false));
            AddColumn("UWT.PageStyles", "Name", c => c.String(nullable: false));
            AddColumn("UWT.PageStyles", "FooterImage_Id", c => c.Long());
            AddColumn("UWT.PageStyles", "NavImage_Id", c => c.Long());
            AddColumn("UWT.Shops", "PageLayout_Id", c => c.Long(nullable: false));
            AlterColumn("UWT.Categories", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("UWT.Categories", "Id");
            CreateIndex("UWT.Categories", "Image_Id");
            CreateIndex("UWT.PageStyles", "FooterImage_Id");
            CreateIndex("UWT.PageStyles", "NavImage_Id");
            CreateIndex("UWT.Shops", "PageLayout_Id");
            AddForeignKey("UWT.Shops", "PageLayout_Id", "UWT.PageLayouts", "Id");
            AddForeignKey("UWT.PageStyles", "FooterImage_Id", "UWT.Images", "Id");
            AddForeignKey("UWT.PageStyles", "NavImage_Id", "UWT.Images", "Id");
            AddForeignKey("UWT.Categories", "Image_Id", "UWT.Images", "Id");
            AddForeignKey("UWT.CategoryProducts", "Category_Id", "UWT.Categories", "Id", cascadeDelete: true);
            DropColumn("UWT.PageStyles", "PageLayout_Id");
        }
        
        public override void Down()
        {
            AddColumn("UWT.PageStyles", "PageLayout_Id", c => c.Long(nullable: false));
            DropForeignKey("UWT.CategoryProducts", "Category_Id", "UWT.Categories");
            DropForeignKey("UWT.Categories", "Image_Id", "UWT.Images");
            DropForeignKey("UWT.PageStyles", "NavImage_Id", "UWT.Images");
            DropForeignKey("UWT.PageStyles", "FooterImage_Id", "UWT.Images");
            DropForeignKey("UWT.Shops", "PageLayout_Id", "UWT.PageLayouts");
            DropIndex("UWT.Shops", new[] { "PageLayout_Id" });
            DropIndex("UWT.PageStyles", new[] { "NavImage_Id" });
            DropIndex("UWT.PageStyles", new[] { "FooterImage_Id" });
            DropIndex("UWT.Categories", new[] { "Image_Id" });
            DropPrimaryKey("UWT.Categories");
            AlterColumn("UWT.Categories", "Id", c => c.Long(nullable: false));
            DropColumn("UWT.Shops", "PageLayout_Id");
            DropColumn("UWT.PageStyles", "NavImage_Id");
            DropColumn("UWT.PageStyles", "FooterImage_Id");
            DropColumn("UWT.PageStyles", "Name");
            DropColumn("UWT.Categories", "Image_Id");
            AddPrimaryKey("UWT.Categories", "Id");
            CreateIndex("UWT.PageStyles", "PageLayout_Id");
            CreateIndex("UWT.Categories", "Id");
            AddForeignKey("UWT.CategoryProducts", "Category_Id", "UWT.Categories", "Id", cascadeDelete: true);
            AddForeignKey("UWT.Categories", "Id", "UWT.Images", "Id");
            AddForeignKey("UWT.PageStyles", "PageLayout_Id", "UWT.PageLayouts", "Id");
        }
    }
}
