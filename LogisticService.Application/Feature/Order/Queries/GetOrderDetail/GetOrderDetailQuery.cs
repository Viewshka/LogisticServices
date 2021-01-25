using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LogisticService.Application.Common.Access;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Application.Feature.Order.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery : IRequest<IEnumerable<OrderDetailsDto>>
    {
        public int OrderId { get; set; }
    }
    
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery,IEnumerable<OrderDetailsDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryHandler(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDetailsDto>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            return await _context.OrderStructures
                .Where(structure => structure.OrderId == request.OrderId)
                .ProjectTo<OrderDetailsDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}