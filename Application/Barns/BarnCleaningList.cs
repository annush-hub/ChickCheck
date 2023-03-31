using Application.Barns.Dtos;
using Application.Storages;
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
    public class BarnCleaningList
    {
        public class Query : IRequest<List<BarnCleaningDto>> 
        {
            public Guid BarnId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<BarnCleaningDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<BarnCleaningDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var cleanings = await _context.Cleanings.Where(x => x.BarnId == request.BarnId)
                    .ProjectTo<BarnCleaningDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken: cancellationToken);

                return cleanings;
            }
        }
    }
}
