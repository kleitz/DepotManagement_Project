using DepotManagement.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IOutBoundRepo
    {
        void ReceiveOrder(OutBoundOrders outBoundOrders, double discount);
        List<Shipment> GetReadyForShipment();
        void AssignShipment(Shipment shipment);
        void ManageStatusOfShipment(int shipmentId, JsonPatchDocument patchDoc);
        void ChangeOrderQuantity(int orderid, JsonPatchDocument patchDoc);
    }
}
