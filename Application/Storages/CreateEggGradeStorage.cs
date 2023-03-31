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
    public class CreateEggGradeStorage
    {
        public class Command : IRequest
        {
            //public EggGardeStorageDto EggGradeStorage { get; set; }
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
                var eggGradeStorage = new EggGradeStorage
                {
                    //EggGradeId = request.EggGradeStorage.EggGradeId,
                    //StorageId = request.EggGradeStorage.StorageId,
                    EggGradeId = request.EggGradeId,
                    StorageId = request.StorageId,
                };


                _context.EggGradeStorages.Add(eggGradeStorage);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
