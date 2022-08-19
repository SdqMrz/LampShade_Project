using _0_FrameWork.Application;
using _0_FrameWork.Infrastructure;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Infrastructure.EFCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        public InventoryRepository(InventoryContext inventoryContext, ShopContext shopContext) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
        }

        public Inventory GetBy(long productId)
        {
            return _inventoryContext.Inventory.FirstOrDefault(x => x.ProductId == productId);
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryContext.Inventory.Select(x => new EditInventory
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            var inventory=_inventoryContext.Inventory.FirstOrDefault(x=>x.Id== inventoryId);    
            return inventory.Operations.Select(x => new InventoryOperationViewModel
            {
                Id= x.Id,
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Operator="مدیر سیستم",
                OperatorId=x.OperatorId,
                OrderId=x.OrderId,
                OperationDate=x.OperationDate.ToFarsi(),
                Description=x.Description,
                Operation=x.Operation
            }).OrderBy(x=>x.Id).ToList();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _inventoryContext.Inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                IsInStock = x.IsInStock,
                CreationDate=x.CreationDate.ToFarsi(),
                CurrentCount = x.CalculateCurrentCount()
            });
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (searchModel.IsInStock)
                query = query.Where(x => !x.IsInStock);

            var inventory = query.OrderByDescending(x => x.Id).ToList();

            inventory.ForEach(item =>
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name);

            return inventory;
        }


    }
}
