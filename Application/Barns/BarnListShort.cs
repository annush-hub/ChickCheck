﻿using Application.Barns.Dtos;
using Application.Core;
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

namespace Application.Barns
{
    public class BarnListShort
    {
        public class Query : IRequest<Result<List<BarnFeedersDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<BarnFeedersDto>>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<BarnFeedersDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var barns = await _context.Barns
                    .ProjectTo<BarnFeedersDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken: cancellationToken);
                return Result<List<BarnFeedersDto>>.Success(barns);
            }
        }
    }
}
