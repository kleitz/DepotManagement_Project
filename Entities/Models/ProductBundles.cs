using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagementService.Models
{
    public class ProductBundles
    {
        private int bundleID;
        private string lotCode;
        private int quantity;
        private DateTime createDate;
        private int productId;
        private int lPNID;
        [Key]
        public int BundleID { get => bundleID; set => bundleID = value; }
        [Column(TypeName = "varchar(50)")]
        public string LotCode { get => lotCode; set => lotCode = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        [ForeignKey("Products")]
        public int ProductId { get => productId; set => productId = value; }
        [ForeignKey("LPN")]
        public int LPNID { get => lPNID; set => lPNID = value; }
        public virtual Products Products { get; set; }
        public virtual LPN LPN { get; set; }
        public int Capacity { get; set; }


    }
}
