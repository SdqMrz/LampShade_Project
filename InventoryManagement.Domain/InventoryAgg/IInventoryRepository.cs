using _0_FrameWork.Application;
using _0_FrameWork.Domain;
using InventoryManagement.Application.Contract.Inventory;
using System.Collections.Generic;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository : IRepository<long, Inventory>
    {
        Inventory GetBy(long productId);
        EditInventory GetDetails(long id);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
    }
}
