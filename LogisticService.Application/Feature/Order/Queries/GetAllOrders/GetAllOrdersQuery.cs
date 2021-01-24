using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LogisticService.Application.Common.Access;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Application.Feature.Order.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<AllOrdersDto>>
    {
    }

    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<AllOrdersDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AllOrdersDto>> Handle(GetAllOrdersQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Orders
                .ProjectTo<AllOrdersDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}