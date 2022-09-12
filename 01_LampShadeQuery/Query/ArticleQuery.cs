using _0_FrameWork.Application;
using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.Comment;
using BolgManagement.Infrastructure.EFCore;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_LampShadeQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _context;
        private readonly CommentContext _commentContext;

        public ArticleQuery(BlogContext context,CommentContext commentContext)
        {
            _context = context;
            _commentContext = commentContext;
        }

        public ArticleQueryModel GetArticleWithDetails(string slug)
        {
            var article= _context.Articles.Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleQueryModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    ShortDescription = x.ShortDescription,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    MetaDescription = x.MetaDescription,
                    KeyWords = x.KeyWords,
                    CanonicalAddress = x.CanonicalAddress,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    CategorySlug = x.Category.Slug,
                    PublishDate = x.PublishDate.ToFarsi()
                }).Where(x=>x.Slug==slug).FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(article.KeyWords))
                article.KeyWordList=article.KeyWords.Split("،").ToList();

            var Comments= _commentContext.Comments
                .Where(x => x.Type == CommentType.Article)
                .Where(x => x.OwnerRecordId == article.Id)
                 .Where(x => x.IsConfirmed)
                .Where(x => !x.IsCanceled)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Message,
                    ParentId = x.ParentId,
                    CreationDate= x.CreationDate.ToFarsi()
                }).OrderByDescending(x => x.Id).ToList();

            foreach(var comment in Comments)
            {
                if(comment.ParentId>0)
                    comment.ParentName=Comments.FirstOrDefault(x=>x.Id==comment.ParentId)?.Name;
            }
            article.Comments = Comments;
            return article;
        }

        public List<ArticleQueryModel> GetLatesArticles()
        {
            return _context.Articles
                .Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleQueryModel
                {
                    Id=x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    PublishDate = x.PublishDate.ToFarsi()
                }).ToList();
        }
    }
}
