using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
