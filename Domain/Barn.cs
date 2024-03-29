﻿using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Barn : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float TemperatureInCelsius { get; set; }
        public float TemperatureInFahrenheit { get; set; }   
        public bool IsDeactivated { get; set; }
        public Guid EggGradeId { get; set; }
        public EggGrade? EggGrade { get; set; }
        public ICollection<Feeder> Feeders { get; set; } = new List<Feeder>();
        public ICollection<Cleaning> Cleanings { get; set; } = new List<Cleaning>();
    }
}
