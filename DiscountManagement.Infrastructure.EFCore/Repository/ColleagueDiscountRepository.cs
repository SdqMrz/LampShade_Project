﻿using _0_FrameWork.Application;
using _0_FrameWork.Infrastructure;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>,IColleagueDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;
        public ColleagueDiscountRepository(DiscountContext context) : base(context)
        {
            _context = context;
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            
            return _context.ColleagueDiscounts.Select(x=>new EditColleagueDiscount
            {
                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate
            }).FirstOrDefault(x=>x.Id == id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var products=_shopContext.Products.Select(x=> new {x.Id,x.Name}).ToList();
            var query = _context.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel
            {
                Id=x.Id,
                ProductId = x.ProductId,
                DiscountRate=x.DiscountRate,
                CreationDate=x.CreationDate.ToFarsi()
            });

            if(searchModel.ProductId>0)
                query=query.Where(x=>x.ProductId==searchModel.ProductId);

            var colleagueDiscounts=query.OrderByDescending(x=>x.Id).ToList();

            colleagueDiscounts.ForEach(discount =>
             discount.Product = products.FirstOrDefault(product => product.Id == discount.ProductId)?.Name);

            return colleagueDiscounts;
        }
    }
}
