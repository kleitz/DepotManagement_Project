using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using SystemManagementService.Models;

namespace Contracts
{
    public interface ISystemManagementRepo
    {
       Products ProductCreationWithType(Products products);
       void UpdatePalletsQuantity(int palletId, JsonPatchDocument patchDoc);
    }
}
