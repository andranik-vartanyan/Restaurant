using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<RestaurantEntity> Restaurants { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RestaurantEntity>(r =>
            {
                r.ToTable("Restaurants");
                r.HasKey(_ => _.Id);
                r.Property(_ => _.Id).ValueGeneratedOnAdd();
                r.HasIndex(_ => _.Name).IsUnique();
                r.HasOne(_ => _.City).WithMany().HasForeignKey(_ => _.CityId);
            });
            builder.Entity<City>(r =>
            {
                r.ToTable("Cities");
                r.HasKey(_ => _.Id);
                r.Property(_ => _.Id).ValueGeneratedOnAdd();
                r.HasIndex(_ => _.Name).IsUnique();
            });
        }
    }
}
