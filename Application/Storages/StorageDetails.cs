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
    public class StorageDetails
    {
        public class Query : IRequest<StorageDetailedDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, StorageDetailedDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            async Task<StorageDetailedDto> IRequestHandler<Query, StorageDetailedDto>.Handle(Query request, CancellationToken cancellationToken)
            {
                var storage = await _context.Storages
                    .ProjectTo<StorageDetailedDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync<StorageDetailedDto>(x => x.Id == request.Id);
                return storage;
            }
        }
    }
}
