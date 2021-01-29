using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LogisticService.Application.Common.Access;
using LogisticService.Core.Entities;
using LogisticService.Core.Entities.Identity;
using LogisticService.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LogisticService.WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IConfiguration configuration,
            ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }

        public async void OnGet()
        {
            var flag = true;

            if (flag && _configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                await AddDataAsync();
                flag = false;
            }
        }

        private async Task AddDataAsync()
        {
            var roles = new[]
            {
                RolesEnum.Manager,
                RolesEnum.Courier,
                RolesEnum.Client
            };

            var hasher = new PasswordHasher<ApplicationUser>();

            foreach (var role in roles)
            {
                var identityRole = new IdentityRole<int>
                {
                    Id = (int) role,
                    Name = role.ToString(),
                    NormalizedName = role.ToString().ToUpper()
                };

                var user = new ApplicationUser
                {
                    Id = (int) role,
                    UserName = role.ToString(),
                    NormalizedUserName = role.ToString().ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, role.ToString().ToLower()),
                    LockoutEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                };

                await _roleManager.CreateAsync(identityRole);
                await _userManager.CreateAsync(user);
                await _userManager.AddToRoleAsync(user, role.ToString());
            }

            var units = new List<Unit>
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
            };


            var serviceTypes = new List<ServiceType>
            {
                new ServiceType
                {
                    Id = 1,
                    Name = "Почтовые",
                    Description = "Почтовые"
                },
                new ServiceType
                {
                    Id = 2,
                    Name = "Курьерская доставка",
                    Description = "Курьерская доставка"
                },
                new ServiceType
                {
                    Id = 3,
                    Name = "Складские услуги",
                    Description = "Складские услуги"
                },
                new ServiceType
                {
                    Id = 4,
                    Name = "Мелкорозничная доставка",
                    Description = "Мелкорозничная доставка"
                },
            };

            await _context.ServiceTypes.AddRangeAsync(serviceTypes);
            await _context.Units.AddRangeAsync(units);
            await _context.SaveChangesAsync();
        }
    }
}