using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EggGrades
{
    public class EggGradeDetails
    {
        public class Query : IRequest<EggGrade>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, EggGrade>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            async Task<EggGrade> IRequestHandler<Query, EggGrade>.Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.EggGrades.FindAsync(request.Id);
            }
        }
    }
}
