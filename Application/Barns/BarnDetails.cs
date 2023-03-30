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
    public class BarnDetails
    {
        public class Query : IRequest<BarnDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, BarnDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            async Task<BarnDto> IRequestHandler<Query, BarnDto>.Handle(Query request, CancellationToken cancellationToken)
            {
                var barn = await _context.Barns
                    .ProjectTo<BarnDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync<BarnDto>(x => x.Id == request.Id);
                return barn;
            }
        }
    }
}
