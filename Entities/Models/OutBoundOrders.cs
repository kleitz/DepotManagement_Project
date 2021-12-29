using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SystemManagementService.Models;

namespace DepotManagement.Models
{
    public class OutBoundOrders
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderAmount { get; set; }
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Customers Customers { get; set; }
        public Products Products { get; set; }
    }
}
