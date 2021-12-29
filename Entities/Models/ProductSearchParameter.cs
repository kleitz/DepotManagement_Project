using DepotManagement.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class ProductSearchParameter: PagingParameters
    {
        public string ProductNumber { get; set; }
    }
}
