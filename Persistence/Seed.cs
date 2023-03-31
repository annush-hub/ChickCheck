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
            if (!context.EggGrades.Any())
            {
                var eggGrades = new List<EggGrade>
                {
                    new EggGrade
                    {
                        GradeUA = "СВ",
                        GradeEU = "XL"
                    },
                    new EggGrade
                    {
                        GradeUA = "С0",
                        GradeEU = "L"
                    },
                    new EggGrade
                    {
                        GradeUA = "С1",
                        GradeEU = "M"
                    },
                    new EggGrade
                    {
                        GradeUA = "С2",
                        GradeEU = "S"
                    },
                };
                await context.EggGrades.AddRangeAsync(eggGrades);
            }

            if (!context.Barns.Any() )
            {

                var barns = new List<Barn>
                {
                    new Barn
                    {
                        Name = "Barn 1",
                        Description = "Barn with M eggs",
                        TemperatureInCelsius = 19f,
                        TemperatureInFahrenheit = 66.2f,
                        IsDeactivated = false,
                        EggGradeId = Guid.Parse("8CE5787A-0EE5-49C9-05B9-08DB308933AF"),
                    },
                    new Barn
                    {
                        Name = "Barn 2",
                        Description = "Barn with L eggs",
                        TemperatureInCelsius = 21f,
                        TemperatureInFahrenheit = 69.8f,
                        IsDeactivated = false,
                        EggGradeId = Guid.Parse("392D4044-47AA-47D0-05BB-08DB308933AF"),
                    },
                    new Barn
                    {
                        Name = "Barn 3",
                        Description = "Barn with L eggs",
                        TemperatureInCelsius = 18f,
                        TemperatureInFahrenheit = 64.4f,
                        IsDeactivated = false,
                        EggGradeId = Guid.Parse("6C4D97B0-C0E0-441D-05BA-08DB308933AF"),
                    },
                    new Barn
                    {
                        Name = "Barn 4",
                        Description = "Barn with S eggs",
                        TemperatureInCelsius = 21f,
                        TemperatureInFahrenheit = 69.8f,
                        IsDeactivated = false,
                        EggGradeId = Guid.Parse("1615F6EC-E1E9-410C-05BC-08DB308933AF"),
                    },
                    new Barn
                    {
                        Name = "Barn 5",
                        Description = "Barn with XL eggs",
                        TemperatureInCelsius = 20f,
                        TemperatureInFahrenheit = 68f,
                        IsDeactivated = false,
                        EggGradeId = Guid.Parse("6C4D97B0-C0E0-441D-05BA-08DB308933AF"),
                    }
                };

                await context.Barns.AddRangeAsync(barns);              

            }

            if (!context.EggGradeStorages.Any())
            {
                var eggGradeStorages = new List<EggGradeStorage>
                    {
                        new EggGradeStorage
                        {
                            EggGradeId = Guid.Parse("6C4D97B0-C0E0-441D-05BA-08DB308933AF"),
                            StorageId = Guid.Parse("CFDEF7BC-268B-40CE-F838-08DB31B3C6F5"),
                        },
                        new EggGradeStorage
                        {
                            EggGradeId = Guid.Parse("6C4D97B0-C0E0-441D-05BA-08DB308933AF"),
                            StorageId = Guid.Parse("3CABFEDA-2F28-417D-73C9-08DB31B38F55"),
                        },
                    };

                await context.EggGradeStorages.AddRangeAsync(eggGradeStorages);
            }
            await context.SaveChangesAsync();
        }
    }
}
