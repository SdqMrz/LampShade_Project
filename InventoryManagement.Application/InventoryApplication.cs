﻿using _0_FrameWork.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public OperationResult Create(CreateInventory command)
        {
            var operation=new OperationResult();
            if(_inventoryRepository.Exist(x=>x.ProductId==command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var inventory = new Inventory(command.ProductId, command.UnitPrice);
            _inventoryRepository.Create(inventory);
            _inventoryRepository.SaveChanges();
            return operation.Successed();
        }

        public OperationResult Edit(EditInventory command)
        {
            var operation=new OperationResult();
            var inventory=_inventoryRepository.Get(command.Id);

            if(inventory==null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if(_inventoryRepository.Exist(x=>x.ProductId==command.ProductId && x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            inventory.Edit(command.ProductId,command.UnitPrice);
            _inventoryRepository.SaveChanges();
            return operation.Successed();
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryRepository.GetDetails(id);
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            var operation=new OperationResult();
            var inventory=_inventoryRepository.Get(command.InventoryId);

            if (inventory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            const long operatorId = 1;
            inventory.Increase(command.Count, operatorId, command.Description);
            _inventoryRepository.SaveChanges();
            return operation.Successed();
        }

        public OperationResult Reduce(ReduceInventory command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);

            if (inventory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            const long operatorId = 1;
            inventory.Reduce(command.Count,operatorId,command.Description,0);
            _inventoryRepository.SaveChanges();
            return operation.Successed();
        }

        public OperationResult Reduce(List<ReduceInventory> command)
        {
            var operation = new OperationResult();
            const long operatorId = 1;

            foreach (var item in command)
            {
                var inventory=_inventoryRepository.GetBy(item.ProductId);
                inventory.Reduce(item.Count, operatorId, item.Description, item.InventoryId);
            }

            _inventoryRepository.SaveChanges();
            return operation.Successed();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            return _inventoryRepository.Search(searchModel);
        }
    }
}
