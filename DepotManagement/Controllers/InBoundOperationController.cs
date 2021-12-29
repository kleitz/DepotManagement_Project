using Contracts;
using DepotManagement.Models;
using Entities;
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
    public class InBoundOperationController : ControllerBase
    {
        readonly ILogger<InBoundOperationController> _log;
        private readonly IInBoundRepo _inBoundRepo;

        public InBoundOperationController(IInBoundRepo inBoundRepo, ILogger<InBoundOperationController> log)
        {
            _inBoundRepo = inBoundRepo;
            _log = log;
        }

        [HttpPost]
        public async Task<ActionResult<InBoundOrders>> CreateOrder(InBoundOrders inBoundOrdersModel)
        {
            _log.LogInformation("LogCreated for // POST InBoundOperationController ");
            try
            {
                InBoundOrders inBoundOrders = _inBoundRepo.CreateOrder(inBoundOrdersModel);
                return Ok(inBoundOrders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured");
            }
        }
        [HttpGet("{id}")]
        public ActionResult VerifyOrderId(int id)
        {
            _log.LogInformation("LogCreated for // GETbyID: InBoundOperationController");
            try
            {
                InBoundOrders orderDetails = _inBoundRepo.VerifyOrderId(id);

                if (orderDetails == null)
                {
                    return NotFound();
                }
                return Ok(orderDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured " + ex.Message);
            }
        }
        //1.	Modify the Pallets quantities
        [Route("PatchPalletSize")]
        [HttpPatch]
        public IActionResult PatchPalletSize(int palletId, [FromBody] JsonPatchDocument patchDoc)
        {
            _log.LogInformation("LogCreated for // HttpPatch:PatchPalletSize InBoundOperationController");
            try
            {
                _inBoundRepo.PatchPalletSize(palletId, patchDoc);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured " + ex.Message);
            }

        }

        //2.	Api to find out Quantities of items are available in the warehouse.
        [HttpGet]
        public ActionResult ItemsQuantites()
        {
            _log.LogInformation("LogCreated for // GET:ItemQuantity InBoundOperationController");
            try
            {
                ProductBundles orderDetails = _inBoundRepo.ItemsQuantites();

                if (orderDetails == null)
                {
                    return NotFound();
                }
                return Ok(orderDetails);
                //return Ok(new { ProductId = orderDetails.ProductId, Quantity = orderDetails.Quantity });
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message);
                return StatusCode(500, "An error occured: {0}" + ex.Message);
            }

        }
    }
}
