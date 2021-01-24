using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LogisticService.Core.Entities.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ICollection<Order> Orders { get; set; }
    }
}