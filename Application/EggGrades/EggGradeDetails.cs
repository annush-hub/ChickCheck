using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.EggGrades
{
    public class EggGradeDetails
    {
        public class Query : IRequest<EggGradeDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, EggGradeDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            async Task<EggGradeDto> IRequestHandler<Query, EggGradeDto>.Handle(Query request, CancellationToken cancellationToken)
            {
                var eggGrade = await _context.EggGrades
                    .ProjectTo<EggGradeDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync<EggGradeDto>(x => x.Id == request.Id);
                return eggGrade;
            }
        }
    }
}
