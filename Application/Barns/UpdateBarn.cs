using Application.Barns.Dtos;
using Application.Core;
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
            public CreateBarnDto Barn { get; set; }
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

                barn.Name = request.Barn.Name;
                barn.Description = request.Barn.Description;
                barn.TemperatureInCelsius = (request.Barn.TemperatureInCelsius == 0 && request.Barn.TemperatureInFahrenheit != 0)
                                            ? TemperatureAdaptor.FahrenheitToCelsius(request.Barn.TemperatureInFahrenheit)
                                            : request.Barn.TemperatureInCelsius;

                barn.TemperatureInFahrenheit = (request.Barn.TemperatureInFahrenheit == 0 && request.Barn.TemperatureInCelsius != 0)
                                            ? TemperatureAdaptor.CelsiusToFahrenheit(request.Barn.TemperatureInCelsius)
                                            : request.Barn.TemperatureInFahrenheit;
                barn.IsDeactivated = request.Barn.IsDeactivated;
                barn.EggGradeId = request.Barn.EggGradeId;

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
