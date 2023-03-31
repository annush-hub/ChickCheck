using Application.EggGrades;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Storages
{
    public class StorageDetailedDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public bool IsWorking { get; set; }
        public ICollection<EggGradeShortDto> EggGrades { get; set; }
    }
}
