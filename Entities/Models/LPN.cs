using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagementService.Models
{
    public class LPN
    {
        private int lPNID;
        private DateTime createDate;
        private string nodeId;
        [Key]
        public int LPNID { get => lPNID; set => lPNID = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        [ForeignKey("Nodes")]
        public string NodeId { get => nodeId; set => nodeId = value; }
        public Nodes Nodes { get; set; }
        public ICollection<ProductBundles> ProductBundle { get; set; }
    }
}
