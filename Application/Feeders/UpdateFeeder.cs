using Application.Barns.Dtos;
using AutoMapper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feeders
{
    public class UpdateFeeder
    {
        public class Command : IRequest
        {
            public FeederDto Feeder { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;


            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {

                var feeder = await _context.Feeders.FindAsync(request.Feeder.Id);

                _mapper.Map(request.Feeder, feeder);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
