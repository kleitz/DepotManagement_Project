using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SystemManagementService.Models;
using DepotManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using System.Web.Http.ModelBinding;
using Contracts;

namespace Repository
{
    public class OutBoundRepo : IOutBoundRepo
    {
        protected ApplicationDbContext _context { get; set; }
        public OutBoundRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void ReceiveOrder(DepotManagement.Models.OutBoundOrders outBoundOrders, double discount)
        {
            outBoundOrders.OrderAmount = OrderAmount(outBoundOrders.ProductId, outBoundOrders.Quantity, outBoundOrders, discount);
            _context.OutBoundOrders.Add(outBoundOrders);
            _context.SaveChanges();

        }
        public double OrderAmount(int id, int quantity, DepotManagement.Models.OutBoundOrders outBoundOrders, double discount)
        {
            double price = (from pr in _context.Products where pr.ProductId == id select pr).First<Products>().ProductPrice;

            price = (1 - (double)discount / 100) * price;

            double totalPrice = Convert.ToDouble(price) * quantity;
            return totalPrice;
        }

        public List<Shipment> GetReadyForShipment()
        {
            List<Shipment> readyStatus = (from sh in _context.Shipments where sh.ShipmentStatus == "Ready for Shipment" select sh).ToList();
            return readyStatus;
        }

        public void AssignShipment(Shipment shipment)
        {
            shipment.EstimatedDelivery = shipment.ShipmentDate.AddDays(7);
            _context.Shipments.Add(shipment);
            _context.SaveChanges();
        }

        public void ManageStatusOfShipment(int id, JsonPatchDocument patchDoc)
        {
            var shipmentData = _context.Shipments.FirstOrDefault(sid => sid.ShipmentId == id);
            if (shipmentData != null)
            {
                patchDoc.ApplyTo(shipmentData);
                _context.SaveChanges();
            }

        }

        public void ChangeOrderQuantity(int orderid, JsonPatchDocument patchDoc)
        {
            var orderData = _context.OutBoundOrders.FirstOrDefault(oid => oid.OrderId == orderid);
            double perPrice = orderData.OrderAmount / orderData.Quantity;
            if (orderData != null)
            {
                patchDoc.ApplyTo(orderData);
                _context.SaveChanges();
                orderData = _context.OutBoundOrders.FirstOrDefault(oid => oid.OrderId == orderid);
                orderData.OrderAmount = orderData.Quantity * perPrice;

                _context.Entry(orderData).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
