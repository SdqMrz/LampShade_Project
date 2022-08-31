using _0_FrameWork.Application;
using _0_FrameWork.Infrastructure;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolgManagement.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepository
    {
        private BlogContext _context;
        public ArticleCategoryRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _context.ArticleCategories.Select(c => new ArticleCategoryViewModel
            {
                Id=c.Id,
                Name=c.Name
            }).ToList();
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _context.ArticleCategories.Select(c => new EditArticleCategory
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                OrderShow = c.OrderShow,
                Slug = c.Slug,
                KeyWords = c.KeyWords,
                MetaDescription = c.MetaDescription,
                PictureTitle = c.PictureTitle,
                PictureAlt = c.PictureAlt,
                CanonicalAddress = c.CanonicalAddress
            }).FirstOrDefault(c => c.Id == id);
        }

        public string GetSlugBy(long id)
        {
            return _context.ArticleCategories
                .Select(x=> new {x.Id,x.Slug})
                .FirstOrDefault(x => x.Id == id).Slug;
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            var query = _context.ArticleCategories.Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                OrderShow = x.OrderShow,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi(),
                //ArticleCount=
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.OrderShow).ToList();
        }
    }
}
