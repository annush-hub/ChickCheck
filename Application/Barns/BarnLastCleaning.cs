using Application.Barns.Dtos;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Barns
{
    public class BarnLastCleaning
    {
        public class Query : IRequest<BarnCleaningDto>
        {
            public Guid BarnId { get; set; }
        }

        public class Handler : IRequestHandler<Query, BarnCleaningDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BarnCleaningDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var cleanings =  _context.Cleanings.Where(x => x.BarnId == request.BarnId);
                var latestDate = cleanings.Max(x => x.CleanedAt);
                var cleaning = cleanings.Where(x => x.CleanedAt == latestDate).FirstOrDefault();

                var user = _context.Users.Where(x => x.Id == cleaning.AppUserId);

                var barnlatestCleaning = new BarnCleaningDto
                {
                    Id = cleaning.Id,
                    User = user.Select(x => x.UserName).FirstOrDefault(),
                    CleanedAt = TimeAdapter.unixToDt(cleaning.CleanedAt)
                };                

                return barnlatestCleaning;
            }

            
        }
    }
}
