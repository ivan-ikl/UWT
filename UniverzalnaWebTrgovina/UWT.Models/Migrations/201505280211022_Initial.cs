namespace UWT.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "UWT.BasketItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        Basket_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("UWT.Baskets", t => t.Basket_Id)
                .ForeignKey("UWT.Products", t => t.Product_Id)
                .Index(t => t.Basket_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "UWT.Baskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        DateClosed = c.DateTime(nullable: false),
                        Owner_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("UWT.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "UWT.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("UWT.Baskets", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "UWT.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Blocked = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "UWT.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("UWT.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "UWT.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("UWT.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "UWT.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateSent = c.DateTime(nullable: false),
                        DateRecieved = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                        Product_Id = c.Int(),
                        Reciever_Id = c.String(nullable: false, maxLength: 128),
                        Sender_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("UWT.Products", t => t.Product_Id)
                .ForeignKey("UWT.AspNetUsers", t => t.Reciever_Id)
                .ForeignKey("UWT.AspNetUsers", t => t.Sender_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Reciever_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "UWT.Products",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Tags = c.String(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        Views = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Shop_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("UWT.Images", t => t.Id)
                .ForeignKey("UWT.Shops", t => t.Shop_Id)
                .Index(t => t.Id)
                .Index(t => t.Shop_Id);
            
            CreateTable(
                "UWT.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Image_Id = c.Int(nullable: false),
                        Shop_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("UWT.Images", t => t.Image_Id)
                .ForeignKey("UWT.Shops", t => t.Shop_Id)
                .Index(t => t.Image_Id)
                .Index(t => t.Shop_Id);
            
            CreateTable(
                "UWT.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Owner_Id = c.String(maxLength: 128),
                        UserProfile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("UWT.AspNetUsers", t => t.Owner_Id)
                .ForeignKey("UWT.AspNetUsers", t => t.UserProfile_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.UserProfile_Id);
            
            CreateTable(
                "UWT.PageStyles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ForegroundColor = c.String(nullable: false),
                        BackgroundColor = c.String(nullable: false),
                        NavColor = c.String(nullable: false),
                        SheetColor = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Owner_Id = c.String(nullable: false, maxLength: 128),
                        BackgroundImage_Id = c.Int(nullable: false),
                        FooterImage_Id = c.Int(),
                        Logo_Id = c.Int(nullable: false),
                        NavImage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("UWT.AspNetUsers", t => t.Owner_Id)
                .ForeignKey("UWT.Images", t => t.BackgroundImage_Id)
                .ForeignKey("UWT.Images", t => t.FooterImage_Id)
                .ForeignKey("UWT.Images", t => t.Logo_Id)
                .ForeignKey("UWT.Images", t => t.NavImage_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.BackgroundImage_Id)
                .Index(t => t.FooterImage_Id)
                .Index(t => t.Logo_Id)
                .Index(t => t.NavImage_Id);
            
            CreateTable(
                "UWT.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Owner_Id = c.String(nullable: false, maxLength: 128),
                        PageLayout_Id = c.Int(nullable: false),
                        PageStyle_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("UWT.AspNetUsers", t => t.Owner_Id)
                .ForeignKey("UWT.PageLayouts", t => t.PageLayout_Id)
                .ForeignKey("UWT.PageStyles", t => t.PageStyle_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.PageLayout_Id)
                .Index(t => t.PageStyle_Id);
            
            CreateTable(
                "UWT.PageLayouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Layout = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Owner_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("UWT.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "UWT.Searches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        SearchText = c.String(nullable: false),
                        Owner_Id = c.String(maxLength: 128),
                        Shop_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("UWT.AspNetUsers", t => t.Owner_Id)
                .ForeignKey("UWT.Shops", t => t.Shop_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.Shop_Id);
            
            CreateTable(
                "UWT.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("UWT.AspNetUsers", t => t.UserId)
                .ForeignKey("UWT.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "UWT.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "UWT.CategoryProducts",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Product_Id })
                .ForeignKey("UWT.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("UWT.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "UWT.SearchProducts",
                c => new
                    {
                        Search_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Search_Id, t.Product_Id })
                .ForeignKey("UWT.Searches", t => t.Search_Id, cascadeDelete: true)
                .ForeignKey("UWT.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Search_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("UWT.AspNetUserRoles", "RoleId", "UWT.AspNetRoles");
            DropForeignKey("UWT.BasketItems", "Product_Id", "UWT.Products");
            DropForeignKey("UWT.BasketItems", "Basket_Id", "UWT.Baskets");
            DropForeignKey("UWT.Baskets", "Owner_Id", "UWT.AspNetUsers");
            DropForeignKey("UWT.AspNetUserRoles", "UserId", "UWT.AspNetUsers");
            DropForeignKey("UWT.Messages", "Sender_Id", "UWT.AspNetUsers");
            DropForeignKey("UWT.Messages", "Reciever_Id", "UWT.AspNetUsers");
            DropForeignKey("UWT.Products", "Shop_Id", "UWT.Shops");
            DropForeignKey("UWT.Searches", "Shop_Id", "UWT.Shops");
            DropForeignKey("UWT.SearchProducts", "Product_Id", "UWT.Products");
            DropForeignKey("UWT.SearchProducts", "Search_Id", "UWT.Searches");
            DropForeignKey("UWT.Searches", "Owner_Id", "UWT.AspNetUsers");
            DropForeignKey("UWT.Messages", "Product_Id", "UWT.Products");
            DropForeignKey("UWT.Products", "Id", "UWT.Images");
            DropForeignKey("UWT.Categories", "Shop_Id", "UWT.Shops");
            DropForeignKey("UWT.CategoryProducts", "Product_Id", "UWT.Products");
            DropForeignKey("UWT.CategoryProducts", "Category_Id", "UWT.Categories");
            DropForeignKey("UWT.Categories", "Image_Id", "UWT.Images");
            DropForeignKey("UWT.Images", "UserProfile_Id", "UWT.AspNetUsers");
            DropForeignKey("UWT.PageStyles", "NavImage_Id", "UWT.Images");
            DropForeignKey("UWT.PageStyles", "Logo_Id", "UWT.Images");
            DropForeignKey("UWT.PageStyles", "FooterImage_Id", "UWT.Images");
            DropForeignKey("UWT.PageStyles", "BackgroundImage_Id", "UWT.Images");
            DropForeignKey("UWT.Shops", "PageStyle_Id", "UWT.PageStyles");
            DropForeignKey("UWT.Shops", "PageLayout_Id", "UWT.PageLayouts");
            DropForeignKey("UWT.PageLayouts", "Owner_Id", "UWT.AspNetUsers");
            DropForeignKey("UWT.Shops", "Owner_Id", "UWT.AspNetUsers");
            DropForeignKey("UWT.PageStyles", "Owner_Id", "UWT.AspNetUsers");
            DropForeignKey("UWT.Images", "Owner_Id", "UWT.AspNetUsers");
            DropForeignKey("UWT.AspNetUserLogins", "UserId", "UWT.AspNetUsers");
            DropForeignKey("UWT.AspNetUserClaims", "UserId", "UWT.AspNetUsers");
            DropForeignKey("UWT.Invoices", "Id", "UWT.Baskets");
            DropIndex("UWT.SearchProducts", new[] { "Product_Id" });
            DropIndex("UWT.SearchProducts", new[] { "Search_Id" });
            DropIndex("UWT.CategoryProducts", new[] { "Product_Id" });
            DropIndex("UWT.CategoryProducts", new[] { "Category_Id" });
            DropIndex("UWT.AspNetRoles", "RoleNameIndex");
            DropIndex("UWT.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("UWT.AspNetUserRoles", new[] { "UserId" });
            DropIndex("UWT.Searches", new[] { "Shop_Id" });
            DropIndex("UWT.Searches", new[] { "Owner_Id" });
            DropIndex("UWT.PageLayouts", new[] { "Owner_Id" });
            DropIndex("UWT.Shops", new[] { "PageStyle_Id" });
            DropIndex("UWT.Shops", new[] { "PageLayout_Id" });
            DropIndex("UWT.Shops", new[] { "Owner_Id" });
            DropIndex("UWT.PageStyles", new[] { "NavImage_Id" });
            DropIndex("UWT.PageStyles", new[] { "Logo_Id" });
            DropIndex("UWT.PageStyles", new[] { "FooterImage_Id" });
            DropIndex("UWT.PageStyles", new[] { "BackgroundImage_Id" });
            DropIndex("UWT.PageStyles", new[] { "Owner_Id" });
            DropIndex("UWT.Images", new[] { "UserProfile_Id" });
            DropIndex("UWT.Images", new[] { "Owner_Id" });
            DropIndex("UWT.Categories", new[] { "Shop_Id" });
            DropIndex("UWT.Categories", new[] { "Image_Id" });
            DropIndex("UWT.Products", new[] { "Shop_Id" });
            DropIndex("UWT.Products", new[] { "Id" });
            DropIndex("UWT.Messages", new[] { "Sender_Id" });
            DropIndex("UWT.Messages", new[] { "Reciever_Id" });
            DropIndex("UWT.Messages", new[] { "Product_Id" });
            DropIndex("UWT.AspNetUserLogins", new[] { "UserId" });
            DropIndex("UWT.AspNetUserClaims", new[] { "UserId" });
            DropIndex("UWT.AspNetUsers", "UserNameIndex");
            DropIndex("UWT.Invoices", new[] { "Id" });
            DropIndex("UWT.Baskets", new[] { "Owner_Id" });
            DropIndex("UWT.BasketItems", new[] { "Product_Id" });
            DropIndex("UWT.BasketItems", new[] { "Basket_Id" });
            DropTable("UWT.SearchProducts");
            DropTable("UWT.CategoryProducts");
            DropTable("UWT.AspNetRoles");
            DropTable("UWT.AspNetUserRoles");
            DropTable("UWT.Searches");
            DropTable("UWT.PageLayouts");
            DropTable("UWT.Shops");
            DropTable("UWT.PageStyles");
            DropTable("UWT.Images");
            DropTable("UWT.Categories");
            DropTable("UWT.Products");
            DropTable("UWT.Messages");
            DropTable("UWT.AspNetUserLogins");
            DropTable("UWT.AspNetUserClaims");
            DropTable("UWT.AspNetUsers");
            DropTable("UWT.Invoices");
            DropTable("UWT.Baskets");
            DropTable("UWT.BasketItems");
        }
    }
}
