using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Application;
using _0_FrameWork.Infrastructure;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductCategory GetDetails(long id)
        {
            return _context.ProductCategories.Select(x => new EditProductCategory()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                //Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi()

            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();
        }

        public string GetSlugBy(long id)
        {
         return _context.ProductCategories.Select(x=> new {x.Id, x.Slug}).FirstOrDefault(x => x.Id == id).Slug;   
        }
    }
}
