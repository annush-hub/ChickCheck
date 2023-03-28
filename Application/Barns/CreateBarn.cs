using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Barns
{
    public class CreateBarn
    {
        public class Command : IRequest
        {
            public Barn Barn { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Barns.Add(request.Barn);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }

        }

    }
}
