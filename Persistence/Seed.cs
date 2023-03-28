using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(AppDbContext context)
        {
            if (context.Barns.Any()) return;

            var barns = new List<Barn>
            {
                new Barn
                {
                    Name = "Barn 1",
                    Description = "Barn with M eggs",
                    TemperatureInCelsius = 19f,
                    TemperatureInFahrenheit = 66.2f,
                    IsDeactivated = false,
                },
                new Barn
                {
                    Name = "Barn 2",
                    Description = "Barn with L eggs",
                    TemperatureInCelsius = 21f,
                    TemperatureInFahrenheit = 69.8f,
                    IsDeactivated = false,
                },
                new Barn
                {
                    Name = "Barn 3",
                    Description = "Barn with L eggs",
                    TemperatureInCelsius = 18f,
                    TemperatureInFahrenheit = 64.4f,
                    IsDeactivated = false,
                },
                new Barn
                {
                    Name = "Barn 4",
                    Description = "Barn with S eggs",
                    TemperatureInCelsius = 21f,
                    TemperatureInFahrenheit = 69.8f,
                    IsDeactivated = false,
                },
                new Barn
                {
                    Name = "Barn 5",
                    Description = "Barn with XL eggs",
                    TemperatureInCelsius = 20f,
                    TemperatureInFahrenheit = 68f,
                    IsDeactivated = false,
                }
            };

            await context.Barns.AddRangeAsync(barns);
            await context.SaveChangesAsync();
        }
    }
}
