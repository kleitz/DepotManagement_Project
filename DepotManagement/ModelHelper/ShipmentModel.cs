using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepotManagement.ModelHelper
{
    public class ShipmentModel
    {
        public int OrderId { get; set; }
        public string ShipmentStatus { get; set; }
        public string DriverName { get; set; }
        public string TruckNo { get; set; }
    }
}
