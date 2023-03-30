using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Barns.Dtos
{
    public class BarnShortDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float TemperatureInCelsius { get; set; }
        public float TemperatureInFahrenheit { get; set; }
        public bool IsDeactivated { get; set; }
    }
}
