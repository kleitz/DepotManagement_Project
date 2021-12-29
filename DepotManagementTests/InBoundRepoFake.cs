using Contracts;
using DepotManagement.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using SystemManagementService.Models;
using Xunit;
using System.Linq;

namespace DepotManagementTests
{
    public class InBoundRepoFake : IInBoundRepo
    {
        private readonly List<InBoundOrders> inBoundOrders;
        private readonly List<ProductBundles> _productBundle;
        public InBoundRepoFake()
        {
            inBoundOrders = new List<InBoundOrders>()
            {
                new InBoundOrders(){InOrderId=1,OrderStatus="Dispatch",Size=4},
                new InBoundOrders(){InOrderId=3,OrderStatus="Ready for Dispatch",Size=9},
                new InBoundOrders(){InOrderId=2,OrderStatus="Delivered",Size=1},
            };
            _productBundle = new List<ProductBundles>()
            {
                new ProductBundles(){BundleID=3,LotCode="L1",Quantity=6,CreateDate=DateTime.Now,ProductId=1,Capacity=10,LPNID=4},
                new ProductBundles(){BundleID=4,LotCode="L1",Quantity=16,CreateDate=DateTime.Now,ProductId=1,Capacity=20,LPNID=4}
            };
        }
    
       

        public InBoundOrders CreateOrder(InBoundOrders inBoundOrdersModel)
        {
            throw new NotImplementedException();
        }

        public ProductBundles ItemsQuantites()
        {
            var data = _productBundle.GroupBy(t => t.ProductId)
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

        public void PatchPalletSize(int palletId, JsonPatchDocument patchDoc)
        {
            throw new NotImplementedException();
        }
        public InBoundOrders VerifyOrderId(int id)
        {

            var orderData = inBoundOrders.Find(i=>i.InOrderId==id);
            return orderData;
        }

    }
}
