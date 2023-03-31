using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Barns.Dtos
{
    public class BarnCleaningDto
    {
        public Guid Id { get; set; }
        public string User { get; set; }

        public DateTime CleanedAt { get; set; }
    }
}
