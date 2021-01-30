using System.Threading;
using System.Threading.Tasks;
using LogisticService.Application.Common.Access;
using LogisticService.Core.Entities.Identity;
using LogisticService.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Application.Feature.User.Commands.AddUserRole
{
    public class AddUserRoleCommand : IRequest
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }

    public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AddUserRoleCommandHandler(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(applicationUser => applicationUser.Id == request.UserId, cancellationToken);
            
            await _userManager.AddToRoleAsync(user, ((RolesEnum) request.RoleId).ToString());
            
            return Unit.Value;
        }
    }
}