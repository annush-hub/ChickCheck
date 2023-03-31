using Application.Feeders;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Storages
{
    public class CreateStorage
    {
        public class Command : IRequest
        {
            public StorageDto Storage { get; set; }
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
                var storage = new Storage
                {
                    Name = request.Storage.Name,
                    City = request.Storage.City,
                    Region = request.Storage.Region,
                    IsWorking = true,
                };


                _context.Storages.Add(storage);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
