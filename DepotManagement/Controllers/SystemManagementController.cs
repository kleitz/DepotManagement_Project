using Contracts;
using DepotManagement.ModelHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagementService.Models;

namespace DepotManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemManagementController : ControllerBase
    {
        readonly ILogger<SystemManagementController> _log;
        private readonly ISystemManagementRepo _systemManagementRepo;

        public SystemManagementController(ISystemManagementRepo systemManagementRepo, ILogger<SystemManagementController> log)
        {
            _systemManagementRepo = systemManagementRepo;
            _log = log;
        }
        [HttpPost]
        [Route("ProductCreationWithType")]
        public ActionResult ProductCreationWithType(ProductHelper productHelper)
        {
            _log.LogInformation("LogCreated for // POST:ProductCreationWithType SystemManagementController ");
            try
            {
                Products products = new Products();
                products.ProductNumber = productHelper.ProductNumber;
                products.ProductDescription = productHelper.ProductDescription;
                products.ProductPrice = productHelper.ProductPrice;
                products.ProductType = productHelper.ProductType;

                var item = _systemManagementRepo.ProductCreationWithType(products);
                //return Ok("Product details assigned successfully!!!");
                return CreatedAtAction("Get", new { id = products.ProductId }, item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured: " + ex.Message);
            }
        }
        //2.	Define Pallets items quantity
        [Route("UpdatePalletsSize")]
        [HttpPatch]
        public async Task<IActionResult> UpdatePalletsSize(int palletId, [FromBody] JsonPatchDocument patchDoc)
        {
            _log.LogInformation("LogCreated for // PATCH:UpdatePalletsSize SystemManagementController ");
            try
            {
                ProductBundles product = new ProductBundles();
                _systemManagementRepo.UpdatePalletsQuantity(palletId, patchDoc);
                return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occured: " + ex.Message);
            }
        }

    }
}
