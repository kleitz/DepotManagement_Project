using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DepotManagement.Models
{
    public class Shipment
    {
        [Key]
        public int ShipmentId { get; set; }
        public DateTime ShipmentDate { get; set; }
        [ForeignKey("OutBoundOrders")]
        public int OrderId { get; set; }
        public string ShipmentStatus { get; set; }
        public string DriverName { get; set; }
        public string TruckNo { get; set; }
        public OutBoundOrders OutBoundOrders { get; set; }
        public DateTime EstimatedDelivery { get; set; }
    }
}
