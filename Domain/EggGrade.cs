﻿using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EggGrade : BaseEntity
    {
        public string GradeUA { get; set; }
        public string GradeEU { get; set; }

        public ICollection<Barn> Barns { get; set; } = new List<Barn>();
        public ICollection<EggGradeStorage> Storages { get; set; } = new List<EggGradeStorage>();
    }
}
