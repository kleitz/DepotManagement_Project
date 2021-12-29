using Contracts;
using DepotManagement.Paging;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagementService.Models;

namespace Repository
{
    public class ProductBundlesRepo : RepositoryBase<ProductBundles>, IProductBundlesRepo
    {
        protected ApplicationDbContext _context { get; set; }

        public ProductBundlesRepo(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public PagedList<ProductBundles> GetPalletsDetailsPaging(PagingParameters pagingParameters)
        {
            return PagedList<ProductBundles>.ToPagedList(FindAll(),
                pagingParameters.PageNumber,
                pagingParameters.PageSize);
        }

        public IEnumerable<Products> GetProductDetails()
        {
            return _context.Products.ToList();
        }

        public bool ProductModelExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        public bool LPNModelExists(int id)
        {
            return _context.LPN.Any(e => e.LPNID == id);
        }

        public void UpdateLPN(int id, LPN lPN)
        {
            _context.Entry(lPN).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public void UpdateProductDetails(int pid, Products products)
        {
            _context.Entry(products).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
