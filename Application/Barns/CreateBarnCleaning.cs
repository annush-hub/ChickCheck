using Application.Barns.Dtos;
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
    public class CreateBarnCleaning
    {
        public class Command : IRequest
        {
            public Guid BarnId { get; set; }
            public string AppUserId { get; set; }
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
                var cleaning = new Cleaning
                {
                    BarnId = request.BarnId,
                    AppUserId = request.AppUserId,
                    CleanedAt = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                };


                _context.Cleanings.Add(cleaning);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
