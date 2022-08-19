using _0_FrameWork.Application;
using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class CreateInventory
    {
        [Range(1,1000000,ErrorMessage=ValidationMessage.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public double UnitPrice { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
