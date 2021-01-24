﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LogisticService.Application.Common.Access;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Application.Feature.ServiceType.Queries.GetServiceTypes
{
    public class GetServiceTypesQuery : IRequest<IEnumerable<ServiceTypeDto>>
    {
    }

    public class GetServiceTypesQueryHandler : IRequestHandler<GetServiceTypesQuery, IEnumerable<ServiceTypeDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetServiceTypesQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServiceTypeDto>> Handle(GetServiceTypesQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.ServiceTypes
                .ProjectTo<ServiceTypeDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}