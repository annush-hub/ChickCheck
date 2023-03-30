using Application.Barns.Dtos;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Barns
{
    public class CreateBarn
    {
        public class Command : IRequest
        {
            public CreateBarnDto Barn { get; set; }
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
                    var barn = new Barn
                    {
                        Name = request.Barn.Name,
                        Description = request.Barn.Description,

                        TemperatureInCelsius = (request.Barn.TemperatureInCelsius == 0 && request.Barn.TemperatureInFahrenheit != 0 )
                                                ? FahrenheitToCelsius(request.Barn.TemperatureInFahrenheit) 
                                                : request.Barn.TemperatureInCelsius,

                        TemperatureInFahrenheit = (request.Barn.TemperatureInFahrenheit == 0 && request.Barn.TemperatureInCelsius != 0)
                                                ? CelsiusToFahrenheit(request.Barn.TemperatureInCelsius) 
                                                : request.Barn.TemperatureInFahrenheit,
                        IsDeactivated = false,
                        EggGradeId = request.Barn.EggGradeId,
                    };       
                

                _context.Barns.Add(barn);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }

            private float CelsiusToFahrenheit(float temp) 
            {
                float res = temp * 1.8f + 32;

                return (float)(Math.Round((double)res, 2));
            }

            private float FahrenheitToCelsius(float temp)
            {
                float res = (temp - 32) / 1.8f;

                return (float)(Math.Round((double)res, 2));
            }
        }

    }
}
