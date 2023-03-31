using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Storage : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public bool IsWorking { get; set; }
        public ICollection<EggGradeStorage> EggGrades { get; set; } = new List<EggGradeStorage>();
    }
}
