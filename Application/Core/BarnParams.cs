using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class BarnParams : PagingParams
    {

        public bool IsActive { get; set; }
        public bool IsInactive { get; set; }

    }
}
