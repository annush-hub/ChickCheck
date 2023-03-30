using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Feeder : BaseEntity
    {
        public float Capacity { get; set; }
        public float Fullness { get; set; }
        public bool IsInUse { get; set; }
        public Guid BarnId { get; set; }
        public Barn Barn { get; set; }
    }
}
