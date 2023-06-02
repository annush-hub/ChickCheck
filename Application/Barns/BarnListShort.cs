using Application.Barns.Dtos;
using Application.Core;
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
    public class BarnListShort
    {
        public class Query : IRequest<Result<PagedList<BarnFeedersDto>>> 
        {
            public PagingParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<BarnFeedersDto>>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<BarnFeedersDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query =  _context.Barns
                    .OrderByDescending(b => b.EggGradeId)
                    .ProjectTo<BarnFeedersDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                return Result<PagedList<BarnFeedersDto>>.Success(
                    await PagedList<BarnFeedersDto>.CreateAsync(query, request.Params.PageNumber,
                        request.Params.PageSize)
                );
            }
        }
    }
}
