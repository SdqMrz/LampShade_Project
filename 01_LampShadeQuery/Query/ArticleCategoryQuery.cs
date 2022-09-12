using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BolgManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_LampShadeQuery.Query
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {
        private readonly BlogContext _context;

        public ArticleCategoryQuery(BlogContext context)
        {
            _context = context;
        }

        public List<ArticleCategoryQueryModel> GetArticleCategories()
        {
            return _context.ArticleCategories.Select(c => new ArticleCategoryQueryModel
            {
                Name = c.Name,
                Picture = c.Picture,
                Slug = c.Slug,
                ArticlesCount = c.Articles.Count

            }).ToList();
        }

        public ArticleCategoryQueryModel GetArticleCategory(string slug)
        {
            var articleCategory= _context.ArticleCategories
                .Include(x => x.Articles)
                .Select(x => new ArticleCategoryQueryModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    Slug = x.Slug,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    CanonicalAddress = x.CanonicalAddress,
                    MetaDescription = x.MetaDescription,
                    ArticlesCount=x.Articles.Count,
                    KeyWords = x.KeyWords,
                    Articles = MapArticles(x.Articles)
                }).FirstOrDefault(x => x.Slug == slug);
            if(!string.IsNullOrWhiteSpace(articleCategory.KeyWords))
            articleCategory.KeyWordList= articleCategory.KeyWords.Split('،').ToList();

            return articleCategory;

        }

        private static List<ArticleQueryModel> MapArticles(List<Article> articles)
        {
            return articles.Select(x => new ArticleQueryModel
            {
                Title = x.Title,
                Slug = x.Slug,
                MetaDescription = x.MetaDescription,
                KeyWords = x.KeyWords,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                CanonicalAddress = x.CanonicalAddress

            }).ToList();
        }
    }
}
