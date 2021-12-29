using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagementService.Models
{
    public class Nodes
    {
        private string nodeId;
        private string nodeName;
        private int nodeType;
        private string zone;
        [Key]
        public string NodeId { get => nodeId; set => nodeId = value; }
        public string NodeName { get => nodeName; set => nodeName = value; }
        public int NodeType { get => nodeType; set => nodeType = value; }
        public string Zone { get => zone; set => zone = value; }
    }
}
