using Application.Barns.Dtos;
using AutoMapper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Barns
{
    public class BarnCleaningCounter
    {
        public class Query : IRequest<BarnCleaningCounterDto>
        {
            public Guid BarnId { get; set; }
        }

        public class Handler : IRequestHandler<Query, BarnCleaningCounterDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BarnCleaningCounterDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var barns = _context.Barns;
                var users = _context.Users;
                var cleaningsJoinBarns = _context.Cleanings.Join(barns,
                                                                              cleaning => cleaning.BarnId,
                                                                              barn => barn.Id,
                                                                              (cleaning, barn) => new { cleaning, barn });

                var cleaningsJoinBarnsUsers = cleaningsJoinBarns.Join(users,
                                                                                   clBarns => clBarns.cleaning.AppUserId,
                                                                                   user => user.Id,
                                                                                   (clBarns, user) => new { clBarns, user });

                var queryGroupBy = cleaningsJoinBarnsUsers
                        .GroupBy(j => j.user.DisplayName);
                var querySelect = queryGroupBy
                       .Select(g => $"Name = {g.Key}, Count = {g.Count(x => x.clBarns.barn.Id == request.BarnId)}").ToList();


                var barnCleaningCounter = new BarnCleaningCounterDto()
                {
                    UsersWithCounts = querySelect
                };
                return barnCleaningCounter;

            }
        }
    }
}
