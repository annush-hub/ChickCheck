using Application.Barns.Dtos;
using Application.Core;
using Domain;
using FluentValidation;
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
        public class Command : IRequest<Result<Unit>>
        {
            public CreateBarnDto Barn { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Barn).SetValidator(new BarnValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                    var barn = new Barn
                    {
                        Name = request.Barn.Name,
                        Description = request.Barn.Description,

                        TemperatureInCelsius = (request.Barn.TemperatureInCelsius == 0 && request.Barn.TemperatureInFahrenheit != 0 )
                                                ? TemperatureAdaptor.FahrenheitToCelsius(request.Barn.TemperatureInFahrenheit) 
                                                : request.Barn.TemperatureInCelsius,

                        TemperatureInFahrenheit = (request.Barn.TemperatureInFahrenheit == 0 && request.Barn.TemperatureInCelsius != 0)
                                                ? TemperatureAdaptor.CelsiusToFahrenheit(request.Barn.TemperatureInCelsius) 
                                                : request.Barn.TemperatureInFahrenheit,
                        IsDeactivated = false,
                        EggGradeId = request.Barn.EggGradeId,
                    };       
                

                _context.Barns.Add(barn);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create Barn");

                return Result<Unit>.Success(Unit.Value);
            }            
        }

    }
}
