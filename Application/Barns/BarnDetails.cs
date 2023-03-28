using Domain;
using MediatR;
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
        public class Query : IRequest<Barn>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Barn>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            async Task<Barn> IRequestHandler<Query, Barn>.Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Barns.FindAsync(request.Id);
            }
        }
    }
}
