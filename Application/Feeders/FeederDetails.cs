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
    public class FeederDetails
    {
        public class Query : IRequest<FeederDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, FeederDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            async Task<FeederDto> IRequestHandler<Query, FeederDto>.Handle(Query request, CancellationToken cancellationToken)
            {
                var feeder = await _context.Feeders
                    .ProjectTo<FeederDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync<FeederDto>(x => x.Id == request.Id);
                return feeder;
            }
        }
    }
}
