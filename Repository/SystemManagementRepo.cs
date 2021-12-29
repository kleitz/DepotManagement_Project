using Contracts;
using Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemManagementService.Models;

namespace Repository
{
    public class SystemManagementRepo : ISystemManagementRepo
    {
        protected ApplicationDbContext _context { get; set; }
        public SystemManagementRepo(ApplicationDbContext context)
        {
            this._context = context;
        }
        public Products ProductCreationWithType(Products products)
        {
            _context.Products.Add(products);
            _context.SaveChanges();
            return _context.Products.Where(i => i.ProductNumber == products.ProductNumber).FirstOrDefault();
        }

        public void UpdatePalletsQuantity(int palletId, JsonPatchDocument patchDoc)
        {
            var palletData = _context.ProductBundles.FirstOrDefault(pid => pid.BundleID == palletId);
            if (palletData != null)
            {
                patchDoc.ApplyTo(palletData);
                _context.SaveChanges();
            }

        }
    }
}
