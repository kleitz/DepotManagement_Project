using DepotManagement.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using SystemManagementService.Models;

namespace Contracts
{
    public interface IProductBundlesRepo
    {
        PagedList<ProductBundles> GetPalletsDetailsPaging(PagingParameters pagingParameters);
        IEnumerable<Products> GetProductDetails();
        void UpdateProductDetails(int pid, Products products);
        void UpdateLPN(int id, LPN lPN);
        bool ProductModelExists(int id);
        bool LPNModelExists(int id);
    }
}
