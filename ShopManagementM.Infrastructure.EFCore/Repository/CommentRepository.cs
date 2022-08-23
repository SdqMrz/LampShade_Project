﻿using _0_FrameWork.Application;
using _0_FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Comment;
using ShopManagement.Domain.CommentAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly ShopContext _context;
        public CommentRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var query = _context.Comments
                .Include(x=>x.Product)
                .Select(x => new CommentViewModel
            {
                Id=x.Id,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                IsCanceled = x.IsCanceled,
                IsConfirmed = x.IsConfirmed,
                ProductName=x.Product.Name,
                CommentDate=x.CreationDate.ToFarsi(),
                ProductId = x.ProductId
            });
            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query=query.Where(x=>x.Name.Contains(searchModel.Name));

             if(!string.IsNullOrWhiteSpace(searchModel.Email))
                query=query.Where(x=>x.Email.Contains(searchModel.Email));

             return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}