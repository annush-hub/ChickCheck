using Application.Barns.Dtos;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feeders
{
    public class CreateFeeder
    {
        public class Command : IRequest
        {
            public FeederDto Feeder { get; set; }
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
                var feeder = new Feeder
                {
                    Capacity = request.Feeder.Capacity,
                    Fullness = request.Feeder.Fullness,
                    IsInUse = true,
                    BarnId = request.Feeder.BarnId,
                };


                _context.Feeders.Add(feeder);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
