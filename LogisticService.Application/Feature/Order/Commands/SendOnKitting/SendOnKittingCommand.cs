using System;
using System.Threading;
using System.Threading.Tasks;
using LogisticService.Application.Common.Access;
using LogisticService.Core.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Application.Feature.Order.Commands.SendOnKitting
{
    public class SendOnKittingCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class SendOnKittingCommandHandler : IRequestHandler<SendOnKittingCommand>
    {
        private readonly ApplicationDbContext _context;

        public SendOnKittingCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SendOnKittingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders
                .FirstOrDefaultAsync(order => order.Id == request.Id, cancellationToken);

            if (entity == null) throw new Exception("Заказ не найден");

            entity.Status = StatusEnum.ПереданНаКомплектацию;
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}