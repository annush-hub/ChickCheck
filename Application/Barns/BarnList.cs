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
        public class Query : IRequest<List<Barn>> { }

        public class Handler : IRequestHandler<Query, List<Barn>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Barn>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Barns.ToListAsync();
            }
        }
    }
}
