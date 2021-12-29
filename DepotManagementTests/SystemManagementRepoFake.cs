using Contracts;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemManagementService.Models;

namespace DepotManagementTests
{
    public class SystemManagementRepoFake : ISystemManagementRepo
    {
        private readonly List<Products> _prod;
        public SystemManagementRepoFake()
        {
            _prod = new List<Products>()
            {
                new Products{ProductId=1,ProductNumber="SE1",ProductPrice=200,ProductType="Mobile"},
                new Products{ProductId=2,ProductNumber="ME1",ProductPrice=240,ProductType="Laptop"}
            };
    }

        public Products ProductCreationWithType(Products products)
        {
             _prod.Add(products);
           return _prod.Where(i => i.ProductNumber == products.ProductNumber).FirstOrDefault();
        }

        public void UpdatePalletsQuantity(int palletId, JsonPatchDocument patchDoc)
        {
            throw new NotImplementedException();
        }
    }
}
