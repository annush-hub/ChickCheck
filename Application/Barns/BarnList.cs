using Application.Barns.Dtos;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;

namespace Application.Barns
{
    public class BarnList
    {
        public class Query : IRequest<Result<List<BarnDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<BarnDto>>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<BarnDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var barns = await _context.Barns
                    .ProjectTo<BarnDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken: cancellationToken);

                return Result<List<BarnDto>>.Success(barns);
            }
        }
    }
}
