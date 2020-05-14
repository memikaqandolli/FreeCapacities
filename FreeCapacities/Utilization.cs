using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCapacities
{
    class Utilization
    {
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }

        public Utilization()
        {

        }

        public Utilization(DateTime _start, DateTime _end)
        {
            start = _start;
            end = _end;
        }

    }
}
