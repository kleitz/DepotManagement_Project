using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagementService.Models
{
    public class NodeEdges
    {
        private int edgeId;
        private string startNode;
        private string endNode;
        private int edgeLength;
        [Key]
        public int EdgeId { get => edgeId; set => edgeId = value; }
        public string StartNode { get => startNode; set => startNode = value; }
        public string EndNode { get => endNode; set => endNode = value; }
        public int EdgeLength { get => edgeLength; set => edgeLength = value; }
    }
}
