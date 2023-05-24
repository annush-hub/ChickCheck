using Application.Barns.Dtos;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Persistence;
using System;

namespace Application.Barns
{
    public class UpdateBarn
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
            private readonly IMapper _mapper;


            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var barn = await _context.Barns.FindAsync(request.Barn.Id);
                //if (barn == null) return null;

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

                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update Barn");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
