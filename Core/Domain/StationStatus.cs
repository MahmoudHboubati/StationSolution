using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class StationStatus
    {
        public int ID { get; set; }
        public int StationID { get; set; }
        public bool isOnline { get; set; }
        public DateTime EventDateTime { get; set; }
    }
}
