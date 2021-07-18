using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Data.Models;

namespace WebApp.Data
{
    public class CarRepairDbContext : IdentityDbContext
    {
        public CarRepairDbContext(DbContextOptions<CarRepairDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Repair> Repairs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Repair>()
                .HasOne(c=>c.Car)
                .WithMany(c => c.Repairs)
                .HasForeignKey(c=>c.CarId)
                .OnDelete(deleteBehavior:DeleteBehavior.Restrict);

            builder.Entity<Car>()
                .HasOne(ft=>ft.FuelType)
                .WithMany(ft => ft.Cars)
                .HasForeignKey(ft=>ft.FuelTypeId)
                .OnDelete(deleteBehavior:DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
