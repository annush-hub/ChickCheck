using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feeders
{
    public class FeederDto
    {
        public Guid Id { get; set; }
        public float Capacity { get; set; }
        public float Fullness { get; set; }
        public bool IsInUse { get; set; }
        public Guid BarnId { get; set; }
    }
}
