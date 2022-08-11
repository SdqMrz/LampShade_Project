using _0_FrameWork.Application;
using _0_FrameWork.Domain;
using InventoryManagement.Application.Contract.Inventory;
using System.Collections.Generic;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository : IRepository<long, Inventory>
    {
        Inventory GetBy(long productId);
        //OperationResult Increase(IncreaseInventory command);
        //OperationResult Decrease(List<DecreaseInventory> command);
        EditInventory GetDetails(long id);
        List<InventorySearchModel> Search(InventorySearchModel searchModel);
    }
}
