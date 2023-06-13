using Microsoft.EntityFrameworkCore;
using realEstateAPI.Models.Domain;

namespace realEstateAPI.Data
{
    public class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        //public DbSet<PropertyStatus> PropertyStatuses { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<PropertyAmenity> PropertyAmenities { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Property>()
                    .HasOne(p => p.PropertyType)
                    .WithMany()
                    .HasForeignKey(p => p.PropertyTypeId);

            modelBuilder.Entity<PropertyAmenity>()
                .HasKey(pa => new { pa.PropertyId, pa.AmenityId });

            modelBuilder.Entity<PropertyAmenity>()
                .HasOne(pa => pa.Property)
                .WithMany()
                .HasForeignKey(pa => pa.PropertyId);

            modelBuilder.Entity<PropertyAmenity>()
                .HasOne(pa => pa.Amenity)
                .WithMany()
                .HasForeignKey(pa => pa.AmenityId);

            modelBuilder.Entity<Property>()
                .Property(p => p.Location)
                .HasMaxLength(100);

            modelBuilder.Entity<Property>()
                .HasIndex(p => p.Location);

            modelBuilder.Entity<Property>()
                .HasIndex(p => new { p.IsForSale, p.IsForRent });
        }
    }
}
