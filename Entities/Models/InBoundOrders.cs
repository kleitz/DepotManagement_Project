using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DepotManagement.Models
{
    public class InBoundOrders
    {
        [Key]
        public int InOrderId { get; set; }
        public string OrderStatus { get; set; }
        public int Size { get; set; }
    }
}
