using _0_FrameWork.Application;
using _01_LampShadeQuery.Contracts.Product;
using _01_LampShadeQuery.Contracts.ProductCategory;
using DiscountManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_LampShadeQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public ProductCategoryQuery(ShopContext context, InventoryContext inventoryContext,
            DiscountContext discountContext)
        {
            _context = context;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public List<ProductCategoryQueryModel> GetCategoryWithProducs()
        {
            var inventory = _inventoryContext.Inventory.Select(x => new {x.ProductId,x.UnitPrice}).ToList();
            var discounts = _discountContext.CustomerDiscounts.Select(x => new {x.ProductId,x.DiscountRate}).ToList();

            var categories= _context.ProductCategories
                .Include(x => x.Products)
                .ThenInclude(x => x.Category).Select(x => new ProductCategoryQueryModel
                {
                    Id= x.Id,
                    Name= x.Name,
                  Products=MapProducts(x.Products)

                }).ToList();

            foreach (var category in categories)
            {
                foreach(var product in category.Products)
                {
                    var productInventory = _inventoryContext.Inventory
                        .FirstOrDefault(x => x.ProductId == product.Id);

                    if(productInventory != null)
                    {
                        var price=productInventory.UnitPrice;
                        product.Price = price.ToMoney();

                        var discount = _discountContext.CustomerDiscounts
                          .FirstOrDefault(x => x.ProductId == product.Id);

                        if (discount!=null)
                        {
                            var discountRate = discount.DiscountRate;
                            product.DiscountRate = discountRate;
                            product.HasDiscount = discountRate > 0;
                            var disCountAmount = (discountRate * price) / 100;
                            product.PriceWithDiscount = (price - discountRate).ToMoney();
                        }
                        
                    }
                }
            }
            return categories;
        }

        private static List<ProductQueryModel> MapProducts(List<Product> products)
        {
               return products.Select(product=> new ProductQueryModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Category = product.Category.Name,
                    Picture = product.Picture,
                    PictureAlt = product.PictureAlt,
                    PictureTitle = product.PictureTitle,
                    Slug = product.Slug,
                }).ToList();
         
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate,
                //Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,

            }).ToList();
        }

        public ProductCategoryQueryModel GetCategoryWithProductsBy(string slug)
        {
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts.Select(x => new { x.ProductId, x.DiscountRate ,x.EndDate}).ToList();

            var category = _context.ProductCategories
                .Include(x => x.Products)
                .ThenInclude(x => x.Category).Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description= x.Description,
                    KeyWords = x.KeyWords,
                    MetaDescription = x.MetaDescription,
                    Slug = x.Slug,
                    Products = MapProducts(x.Products)
                }).FirstOrDefault(x=>x.Slug==slug);

                foreach (var product in category.Products)
                {
                    var productInventory = _inventoryContext.Inventory
                        .FirstOrDefault(x => x.ProductId == product.Id);

                    if (productInventory != null)
                    {
                        var price = productInventory.UnitPrice;
                        product.Price = price.ToMoney();

                        var discount = _discountContext.CustomerDiscounts
                          .FirstOrDefault(x => x.ProductId == product.Id);

                        if (discount != null)
                        {
                            var discountRate = discount.DiscountRate;
                            product.DiscountRate = discountRate;
                            product.HasDiscount = discountRate > 0;
                            var disCountAmount = (discountRate * price) / 100;
                            product.PriceWithDiscount = (price - discountRate).ToMoney();

                        product.DiscountExpireDate=discount.EndDate.ToDiscountFormat();
                        }
                    }
                }
            return category;
        }
    }
}
