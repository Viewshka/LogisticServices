using System;
using System.Collections.Generic;
using LogisticService.Core.Entities;
using LogisticService.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Application.Common.Access
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStructure> OrderStructures { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Unit> Units { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole<int>>().HasData(new List<IdentityRole<int>>
            {
                new IdentityRole<int>
                {
                    Id = 1,
                    Name = "Manager",
                    NormalizedName = "Manager".ToUpper()
                },
                new IdentityRole<int>
                {
                    Id = 2,
                    Name = "Client",
                    NormalizedName = "Client".ToUpper()
                },
                new IdentityRole<int>
                {
                    Id = 3,
                    Name = "Courier",
                    NormalizedName = "Courier".ToUpper()
                }
            });

            builder.Entity<Unit>().HasData(new List<Unit>
            {
                new Unit
                {
                    Id = 1,
                    FullName = "Грамм",
                    ShortName = "гр",
                    Description = "Грамм"
                },
                new Unit
                {
                    Id = 2,
                    FullName = "Килограмм",
                    ShortName = "кг",
                    Description = "Килограмм"
                },
                new Unit
                {
                    Id = 3,
                    FullName = "Метр",
                    ShortName = "м",
                    Description = "Метр"
                },
                new Unit
                {
                    Id = 4,
                    FullName = "Штука",
                    ShortName = "шт",
                    Description = "Штука"
                },
                new Unit
                {
                    Id = 5,
                    FullName = "Кубический метр",
                    ShortName = "куб. м",
                    Description = "Кубический метр"
                }
            });

            base.OnModelCreating(builder);
        }
    }
}