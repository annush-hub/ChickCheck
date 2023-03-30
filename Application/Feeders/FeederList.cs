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

namespace Application.Feeders
{
    public class FeederList
    {
        public class Query : IRequest<List<FeederDto>> { }

        public class Handler : IRequestHandler<Query, List<FeederDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<FeederDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var feeder = await _context.Feeders
                    .ProjectTo<FeederDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken: cancellationToken);

                return feeder;
            }
        }
    }
}
