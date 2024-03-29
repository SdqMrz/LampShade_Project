﻿using _0_FrameWork.Application;
using _01_LampShadeQuery.Contracts.Comment;
using _01_LampShadeQuery.Contracts.Product;
using CommentManagement.Infrastructure.EFCore;
using DiscountManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_LampShadeQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _context;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;
        private readonly CommentContext _commentContext;

        public ProductQuery(ShopContext context, InventoryContext inventoryContext,
            DiscountContext discountContext, CommentContext commentContext)
        {
            _context = context;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
            _commentContext = commentContext;
        }

        public List<ProductQueryModel> GetLatesProducts()
        {
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts.Select(x => new { x.ProductId, x.DiscountRate }).ToList();

            var products = _context.Products
                .Include(x => x.Category)
                .Include(x => x.ProductPictures).Select(product => new ProductQueryModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Category = product.Category.Name,
                    CategorySlug = product.Category.Slug,
                    Picture = product.Picture,
                    PictureAlt = product.PictureAlt,
                    PictureTitle = product.PictureTitle,
                    Slug = product.Slug
                }).OrderByDescending(x => x.Id).Take(6).ToList();

            foreach (var product in products)
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
                    }

                }
            }
            return products;
        }

        public ProductQueryModel GetProductDetails(string slug)
        {
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice, x.IsInStock }).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.ProductId, x.DiscountRate, x.EndDate }).ToList();

            var product = _context.Products
                .Include(x => x.Category)
                .Select(x => new ProductQueryModel
                {
                    Id = x.Id,
                    Category = x.Category.Name,
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Pictures = MapProductPictures(x.ProductPictures),
                    Slug = x.Slug,
                    CategorySlug = x.Category.Slug,
                    Code = x.Code,
                    Description = x.Description,
                    Keywords = x.keyWords,
                    MetaDescription = x.MetaDescription,
                    ShortDescription = x.ShortDescription,
                }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);

            if (product == null)
                return new ProductQueryModel();

            var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
            if (productInventory != null)
            {
                product.IsInStock = productInventory.IsInStock;
                var price = productInventory.UnitPrice;
                product.Price = price.ToMoney();
                product.DoublePrice = price;
                var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                if (discount != null)
                {
                    var discountRate = discount.DiscountRate;
                    product.DiscountRate = discountRate;
                    product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                    product.HasDiscount = discountRate > 0;
                    var discountAmount = Math.Round((price * discountRate) / 100);
                    product.PriceWithDiscount = (price - discountAmount).ToMoney();
                }
            }
            product.Comments=_commentContext.Comments
                .Where(x=>x.Type== CommentType.Product)
                .Where(x => x.OwnerRecordId == product.Id)
                 .Where(x => x.IsConfirmed)
                .Where(x => !x.IsCanceled)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Message
                }).OrderByDescending(x => x.Id).ToList();
            return product;
        }

        public List<ProductQueryModel> Search(string value)
        {
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.ProductId, x.DiscountRate }).ToList();

            var query = _context.Products
                .Include(x => x.Category)
                .Include(x => x.ProductPictures)
                .Select(product => new ProductQueryModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Category = product.Category.Name,
                    CategorySlug = product.Category.Slug,
                    Picture = product.Picture,
                    PictureAlt = product.PictureAlt,
                    PictureTitle = product.PictureTitle,
                    Pictures = MapProductPictures(product.ProductPictures),
                    Slug = product.Slug,
                    Description = product.Description
                }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(value))
                query = query.Where(x => x.Name.Contains(value) || x.Description.Contains(value)); ;

            var products = query.OrderByDescending(x => x.Id).ToList();

            foreach (var product in products)
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
                    }

                }
            }
            return products;
        }

        private static List<ProductPictureQueryModel> MapProductPictures(List<ProductPicture> productPictures)
        {
            return productPictures.Select(x => new ProductPictureQueryModel
            {
                IsRemoved = x.IsRemoved,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
            }).Where(x => !x.IsRemoved).ToList();
        }
    }
}
