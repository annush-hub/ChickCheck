using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public static class TemperatureAdaptor
    {
        public static float CelsiusToFahrenheit(float temp)
        {
            float res = temp * 1.8f + 32;

            return (float)(Math.Round((double)res, 2));
        }

        public static float FahrenheitToCelsius(float temp)
        {
            float res = (temp - 32) / 1.8f;

            return (float)(Math.Round((double)res, 2));
        }
    }
}
