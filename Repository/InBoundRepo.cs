using DepotManagement.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq;
using SystemManagementService.Models;
using Contracts;

namespace Repository
{
    public class InBoundRepo : IInBoundRepo
    {
        protected ApplicationDbContext _context { get; set; }


        public InBoundRepo(ApplicationDbContext context)
        {
            this._context = context;
        }
        public InBoundOrders CreateOrder(InBoundOrders inBoundOrdersModel)
        {
            _context.InBoundOrders.Add(inBoundOrdersModel);
            _context.SaveChanges();
            return inBoundOrdersModel;
        }
        public InBoundOrders VerifyOrderId(int id)
        {
            var orderData = _context.InBoundOrders.Find(id);
            return orderData;
        }

        public void PatchPalletSize(int palletId, JsonPatchDocument patchDoc)
        {
            var palletData = _context.ProductBundles.FirstOrDefault(pid => pid.BundleID == palletId);
            if (palletData != null)
            {
                patchDoc.ApplyTo(palletData);
                _context.SaveChanges();
            }
        }

        public ProductBundles ItemsQuantites()
        {
            var data = _context.ProductBundles.GroupBy(t => t.ProductId)
                .Select(t => new
                {
                    ProductId = t.Key,
                    Quantity = t.Sum(ta => ta.Quantity)
                }).First();
            ProductBundles productBundles = new ProductBundles();
            productBundles.ProductId = data.ProductId;
            productBundles.Quantity = data.Quantity;
            return productBundles;

        }
    }
}
