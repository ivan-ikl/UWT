using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using UWT.Models.Models;

namespace UWT.Models {

    public class UwtContext : IdentityDbContext<User>
    {

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<BasketItem> BasketItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<PageStyle> PageStyles { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<PageLayout> PageLayouts { get; set; }
        public virtual DbSet<Search> Searches { get; set; }
        public virtual DbSet<IdentityUserClaim> Claims { get; set; }
        public virtual DbSet<IdentityUserLogin> Logins { get; set; }

        public UwtContext() : base("UWTContext", throwIfV1Schema: false) { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("UWT");
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
        public static UwtContext Create() { return new UwtContext(); }

    }
}
