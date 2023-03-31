using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Storages
{
    public class DeleteEggGradeStorage
    {
        public class Command : IRequest
        {
            public Guid EggGradeId { get; set; }
            public Guid StorageId { get; set; }
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
                var eggGradeStorage = await _context.EggGradeStorages.FindAsync(request.EggGradeId, request.StorageId);

                _context.EggGradeStorages.Remove(eggGradeStorage);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
