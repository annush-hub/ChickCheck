using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cleaning : BaseEntity
    {
        public Guid BarnId { get; set; }
        public Barn Barn { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int CleanedAt { get; set; }
    }
}
