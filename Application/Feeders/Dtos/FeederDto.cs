using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feeders.Dtos
{
    public class FeederDto
    {
        public float Capacity { get; set; }
        public float Fullness { get; set; }
        public bool IsInUse { get; set; }
        public Guid BarnId { get; set; }
    }
}
