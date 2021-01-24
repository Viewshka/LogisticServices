using System;
using System.Collections.Generic;
using LogisticService.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Application.Common.Access
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

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

            // builder.Entity<ApplicationUser>().HasData(new List<ApplicationUser>
            // {
            //     new ApplicationUser
            //     {
            //         Id = 1,
            //         UserName = "Ivan",
            //         NormalizedUserName = "Ivan".ToUpper(),
            //         EmailConfirmed = true,
            //         PasswordHash = hasher.HashPassword(null, "ivan"),
            //         LockoutEnabled = true,
            //         SecurityStamp = new Guid().ToString("D"),
            //     }
            // });
            //
            // builder.Entity<IdentityUserRole<int>>().HasData(new List<IdentityUserRole<int>>
            // {
            //     new IdentityUserRole<int>
            //     {
            //         RoleId = 1,
            //         UserId = 1
            //     }
            // });

            base.OnModelCreating(builder);
        }
    }
}