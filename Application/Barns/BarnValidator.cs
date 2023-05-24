using Application.Barns.Dtos;
using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Barns
{
    public class BarnValidator : AbstractValidator<CreateBarnDto>
    {
        public BarnValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.EggGradeId).NotEmpty();
        }
    }
}
