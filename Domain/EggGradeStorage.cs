using Domain.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EggGradeStorage
    {
        public Guid EggGradeId { get; set; }
        public EggGrade EggGrade { get; set; }
        public Guid StorageId { get; set; }
        public Storage Storage { get; set; }
    }
}
