﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWT.Models.Models;

namespace UWT.Models {
    public class UWTContext : IdentityDbContext<User> {

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

        public UWTContext() : base("UWTContext", throwIfV1Schema: false) { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("UWT");
            base.OnModelCreating(modelBuilder);
        }
        public static UWTContext Create() { return new UWTContext(); }

    }
}
