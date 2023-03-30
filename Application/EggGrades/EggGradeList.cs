﻿using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EggGrades
{
    public class EggGradeList
    {
        public class Query : IRequest<List<EggGrade>> { }

        public class Handler : IRequestHandler<Query, List<EggGrade>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<List<EggGrade>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.EggGrades.ToListAsync();
            }
        }
    }
}
