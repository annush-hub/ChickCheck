using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Barns
{
    public class CreateBarnDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float TemperatureInCelsius { get; set; }
        public float TemperatureInFahrenheit { get; set; }
        public Guid EggGradeId { get; set; }
    }
}
