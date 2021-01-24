﻿using System;
using System.Threading;
using System.Threading.Tasks;
using LogisticService.Application.Common.Access;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Application.Feature.Order.Commands.ClientIsRemoveOrder
{
    public class ClientIsRemoveOrderCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class ClientIsRemoveOrderCommandHandler : IRequestHandler<ClientIsRemoveOrderCommand>
    {
        private readonly ApplicationDbContext _context;

        public ClientIsRemoveOrderCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ClientIsRemoveOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders
                .FirstOrDefaultAsync(order => order.Id == request.Id, cancellationToken);

            if (entity == null) throw new Exception("Заказа не существует");

            entity.IsRemove = true;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}