using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LogisticService.Application.Common.Access;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Unit = LogisticService.Core.Entities.Unit;

namespace LogisticService.Application.Feature.Units.Queries
{
    public class GetAllUnitsQuery : IRequest<IEnumerable<Unit>>
    {
    }

    public class GetAllUnitsQueryHandler : IRequestHandler<GetAllUnitsQuery, IEnumerable<Unit>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllUnitsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Unit>> Handle(GetAllUnitsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Units.AsQueryable().AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}