using Application.Feeders;
using AutoMapper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Storages
{
    public class UpdateStorage
    {
        public class Command : IRequest
        {
            public StorageDto Storage { get; set; }
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

                var storage = await _context.Storages.FindAsync(request.Storage.Id);

                _mapper.Map(request.Storage, storage);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
