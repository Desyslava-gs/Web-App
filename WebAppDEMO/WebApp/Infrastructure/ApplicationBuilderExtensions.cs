using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Data;
using WebApp.Data.Models;

namespace WebApp.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
          this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var data = scopedServices.ServiceProvider.GetService<CarRepairDbContext>();

            data.Database.Migrate();

            SeedRepairs(data);
            SeedFuels(data);
            return app;
        }

        private static void SeedRepairs(CarRepairDbContext data)
        {
            if (data.Repairs.Any())
            {
                return;
            }

            data.Repairs.AddRange(new[]
            {
                new Repair {TypeOfRepair = "Replacement Of Consumables"},
                new Repair {TypeOfRepair = "Repair"},
            });

            data.SaveChanges();
        }
        private static void SeedFuels(CarRepairDbContext data) 
        {
            if (data.FuelTypes.Any())
            {
                return;
            }

            data.FuelTypes.AddRange(new[]
            {
                new FuelType {Name = "PETROL"},
                new FuelType {Name = "DIESEL"},
                new FuelType {Name = "GAS"},
                new FuelType {Name = "METHANE"},
                new FuelType {Name = "ELECTRIC"},
                new FuelType {Name = "HYBRID"},
                new FuelType {Name = "METHANE"},
            });

            data.SaveChanges();
        }
     
    }
}
