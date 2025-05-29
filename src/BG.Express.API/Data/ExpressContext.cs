using Microsoft.EntityFrameworkCore;
using BG.Express.API.Data.Entity;
using Beymen.IT.Package.EntityFrameworkCore;
using BG.Express.API.Data.Entities;

namespace BG.Express.API.Data
{
    public class ExpressContext : BaseDbContext
    {
        public ExpressContext(DbContextOptions<ExpressContext> options) : base(options)
        {
        }

        // DbSet Tanımlamaları
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
         public DbSet<Delivery> Deliveries { get; set; }



        // Model yapılandırması
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Delivery ile Address arasında Foreign Key ilişkisi
            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasKey(d => d.Id);

                // AddressId ile Address tablosuna ilişki
                entity.HasOne<Address>()
                    .WithMany()
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.Cascade); // Address silindiğinde, bağlı Delivery kayıtlarını da siler.
            });
        }

    }

}

