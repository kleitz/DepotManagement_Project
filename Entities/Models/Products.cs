using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagementService.Models
{
    public class Products
    {
        private int productId;
        private string productNumber;
        private string productDescription;
        [Key]
        public int ProductId { get => productId; set => productId = value; }
        [Column(TypeName = "varchar(50)")]
        public string ProductNumber { get => productNumber; set => productNumber = value; }
        [Column(TypeName = "varchar(80)")]
        public string ProductDescription { get => productDescription; set => productDescription = value; }
        public double ProductPrice { get; set; }
        public string ProductType{ get; set; }

        public virtual ICollection<ProductBundles> ProductBundle { get; set; }
    }
}
