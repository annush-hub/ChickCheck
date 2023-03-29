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
    public class DeleteBarn
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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
                var barn = await _context.Barns.FindAsync(request.Id);
                _context.Barns.Remove(barn);

                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
