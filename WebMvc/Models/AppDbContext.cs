using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebMvc.Models
{
   
        public class AppDbContext : DbContext
        {
            public AppDbContext() : base("Restoran")
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Migrations.Configuration>("Restoran"));
            }
            public DbSet<Sube> Sube { get; set; }
            public DbSet<Urunler> Urunler { get; set; }
            public DbSet<User> User { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
    }
    
}