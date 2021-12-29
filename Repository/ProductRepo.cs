using Contracts;
using DepotManagement.Paging;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemManagementService.Models;

namespace Repository
{
    public class ProductRepo : RepositoryBase<Products>
    {
        public ProductRepo(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public PagedList<Products> SearchProductDetails(ProductSearchParameter productSearchParameter)
        {
            var products = FindByCondition(o => o.ProductNumber == productSearchParameter.ProductNumber);

            SearchByNumber(ref products, productSearchParameter.ProductNumber);

            return PagedList<Products>.ToPagedList(products.OrderBy(on => on.ProductNumber),
                productSearchParameter.PageNumber,
                productSearchParameter.PageSize);
        }
        private void SearchByNumber(ref IQueryable<Products> products, string oproductName)
        {
            if (!products.Any() || string.IsNullOrWhiteSpace(oproductName))
                return;

            products = products.Where(o => o.ProductNumber.ToLower().Contains(oproductName.Trim().ToLower()));
        }
    }
}
