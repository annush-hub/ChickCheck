using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;

namespace Application.Barns
{
    public class UpdateBarn
    {
        public class Command : IRequest
        {
            public Barn Barn { get; set; }
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
                var barn = await _context.Barns.FindAsync(request.Barn.Id);

                _mapper.Map(request.Barn, barn);

                await _context.SaveChangesAsync();               

                return Unit.Value;
            }
        }
    }
}
