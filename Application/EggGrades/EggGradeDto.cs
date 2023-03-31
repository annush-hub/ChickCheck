using Application.Barns.Dtos;
using Application.Storages;
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

        public ICollection<BarnShortDto> Barns { get; set; }
        public ICollection<StorageDto> Storages { get; set; }
    }
}
