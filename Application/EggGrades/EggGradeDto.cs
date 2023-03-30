using Application.Barns.Dtos;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EggGrades
{
    public class EggGradeDto
    {
        public Guid Id { get; set; }
        public string GradeUA { get; set; }
        public string GradeEU { get; set; }

        public ICollection<BarnDto> Barns { get; set; }
    }
}
