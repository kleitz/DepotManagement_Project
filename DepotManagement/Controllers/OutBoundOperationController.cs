using Contracts;
using DepotManagement.ModelHelper;
using DepotManagement.Models;
using Entities.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepotManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutBoundOperationController : ControllerBase
    {
        readonly ILogger<OutBoundOperationController> _log;
        private readonly IOutBoundRepo _outBoundRepo;
        public OutBoundOperationController(IOutBoundRepo outBoundRepo, ILogger<OutBoundOperationController> log)
        {
            _outBoundRepo = outBoundRepo;
            _log = log;
        }
        //1.	Receive orders from customers
        //3.	Provide discounts and offers for the customer- 
        [HttpPost]
        [Route("ReceiveOrder")]
        public async Task<ActionResult<OutBoundModel>> ReceiveOrder(OutBoundModel outBoundModel, double discount)
        {
            _log.LogInformation("LogCreated for // POST:ReceiveOrder OutBoundOperationController ");
            try
            {
                OutBoundOrders outBoundOrders = new OutBoundOrders();
                TotalPrice totalPrice = new TotalPrice();
                outBoundOrders.CustomerId = outBoundModel.CustomerId;
                outBoundOrders.OrderDate = DateTime.Now;
                outBoundOrders.ProductId = outBoundModel.ProductId;
                outBoundOrders.Quantity = outBoundModel.Quantity;
                _outBoundRepo.ReceiveOrder(outBoundOrders, discount);
                return Ok("order created succefully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured");
            }
        }

        //1.	See items ready for the shipment
        [HttpGet]
        [Route("GetReadyForShipment")]
        public ActionResult<IEnumerable<Shipment>> GetReadyForShipment()
        {
            _log.LogInformation("LogCreated for // GET:GetReadyForShipment OutBoundOperationController ");
            try
            {
                List<Shipment> readyStatus = _outBoundRepo.GetReadyForShipment();
                return Ok(readyStatus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured " + ex.Message);
            }
        }

        //2.	Assign trucks for the shipment
        //3.	Assign driver for the shipment.

        [HttpPost]
        [Route("AssignShipment")]
        public async Task<ActionResult> AssignShipment(ShipmentModel shipmentModel)
        {
            _log.LogInformation("LogCreated for // POST:AssignShipment OutBoundOperationController ");
            try
            {
                Shipment shipment = new Shipment();
                shipment.ShipmentDate = DateTime.Now;
                shipment.OrderId = shipmentModel.OrderId;
                shipment.ShipmentStatus = shipmentModel.ShipmentStatus;
                shipment.DriverName = shipmentModel.DriverName;
                shipment.TruckNo = shipmentModel.TruckNo;
                _outBoundRepo.AssignShipment(shipment);
                return Ok("Shipment assigned successfully!!!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured " + ex.Message);
            }
        }

        //2.	Manage status of the shipment
        [Route("ManageStatusOfShipment")]
        [HttpPatch]
        public async Task<IActionResult> ManageStatusOfShipment(int shipmentId, [FromBody] JsonPatchDocument patchDoc)
        {
            _log.LogInformation("LogCreated for // PATCH:ManageStatusOfShipment OutBoundOperationController ");
            try
            {
                Shipment shipment = new Shipment();
                _outBoundRepo.ManageStatusOfShipment(shipmentId, patchDoc);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured " + ex.Message);
            }

        }

        [Route("ChangeOrderQuantity")]
        [HttpPatch]
        public async Task<IActionResult> ChangeOrderQuantity(int orderid, [FromBody] JsonPatchDocument patchDoc)
        {
            _log.LogInformation("LogCreated for // PATCH:ChangeOrderQuantity OutBoundOperationController ");
            try
            {
                Shipment shipment = new Shipment();
                _outBoundRepo.ChangeOrderQuantity(orderid, patchDoc);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured " + ex.Message);
            }

        }




    }
}
