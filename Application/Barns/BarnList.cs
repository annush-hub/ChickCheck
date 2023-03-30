using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Barns
{
    public class BarnList
    {
        public class Query : IRequest<List<BarnDto>> { }

        public class Handler : IRequestHandler<Query, List<BarnDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<BarnDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var barns = await _context.Barns
                    .ProjectTo<BarnDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken: cancellationToken);

                return barns;
                //return await _context.Barns.ToListAsync();
            }
        }
    }
}
