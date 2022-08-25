using _0_FrameWork.Application;
using _0_FrameWork.Infrastructure;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolgManagement.Infrastructure.EFCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    {
        private readonly BlogContext _blogContext;
        public ArticleRepository(BlogContext blogcontext) : base(blogcontext)
        {
            _blogContext = blogcontext;
        }

        public EditArticle GetDetails(long id)
        {
            return _blogContext.Articles.Select(a => new EditArticle
            {
                Id = a.Id,
                Title = a.Title,
                ShortDescription = a.ShortDescription,
                Description = a.Description,
                PublishDate=a.PublishDate.ToFarsi(),
                PictureAlt = a.PictureAlt,
                PictureTitle = a.PictureTitle,
                Slug = a.Slug,
                KeyWords = a.KeyWords,
                MetaDescription = a.MetaDescription,
                CanonicalAddress = a.CanonicalAddress,
                CategoryId = a.CategoryId,

            }).FirstOrDefault(x=>x.Id==id);
        }

        public Article GetWithCategory(long id)
        {
            return _blogContext.Articles.Include(x=>x.Category).FirstOrDefault(x=>x.Id==id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _blogContext.Articles.Select(a => new ArticleViewModel
            {
                Id=a.Id,
                Title = a.Title,
                ShortDescription=a.ShortDescription,
                PublishDate=a.PublishDate.ToFarsi(),
                Picture=a.Picture,
                Category=a.Category.Name,
                CategoryId=a.CategoryId,
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            if (searchModel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
