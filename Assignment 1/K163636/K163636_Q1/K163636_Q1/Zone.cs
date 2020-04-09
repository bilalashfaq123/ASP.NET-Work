using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K163636_Q1
{
    class Zone
    {
        public String ZoneName { get; set; }
        public String Status { get; set; }

        public Zone(String name, String Status)
        {
            this.ZoneName = name;
            this.Status = Status;
        }
    }
}
