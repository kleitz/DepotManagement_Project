using DepotManagement.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using SystemManagementService.Models;

namespace Contracts
{
    public interface IInBoundRepo
    {
        InBoundOrders CreateOrder(InBoundOrders inBoundOrdersModel);
        InBoundOrders VerifyOrderId(int id);
        void PatchPalletSize(int palletId, JsonPatchDocument patchDoc);
        ProductBundles ItemsQuantites();
    }
}
