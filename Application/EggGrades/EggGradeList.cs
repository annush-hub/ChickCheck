using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.EggGrades
{
    public class EggGradeList
    {
        public class Query : IRequest<List<EggGradeDto>> { }

        public class Handler : IRequestHandler<Query, List<EggGradeDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<EggGradeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var eggGrades = await _context.EggGrades
                    .ProjectTo<EggGradeDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken: cancellationToken);

                return eggGrades;
            }
        }
    }
}
