using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCapacities
{
    public class Capacity
    {
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public Capacity()
        {

        }
        public Capacity(DateTime _start, DateTime _end)
        {
            start = _start;
            end = _end;
        }

    }
}
