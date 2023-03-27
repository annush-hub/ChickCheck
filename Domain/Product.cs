using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product : BaseEntity
    {
        public string? GradeUA { get; set; }
        public string? GradeEU { get; set; }

    }
}
