using Application.EggGrades;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Storages
{
    public class StorageList
    {
        public class Query : IRequest<List<StorageDetailedDto>> { }

        public class Handler : IRequestHandler<Query, List<StorageDetailedDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<StorageDetailedDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var storages = await _context.Storages
                    .ProjectTo<StorageDetailedDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken: cancellationToken);

                return storages;
            }
        }
    }
}
