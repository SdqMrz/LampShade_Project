using _0_FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductPictureRepository:RepositoryBase<long,ProductPicture>,IProductPictureRepository
    {
        private readonly ShopContext _context;
        public ProductPictureRepository(ShopContext context):base(context)
        {
            _context=context;
        }

        public EditProductPicture GetDetails(long id)
        {
            return _context.PropeProductPictures.Select(x=> new EditProductPicture
            {
                Id=x.Id,
                ProductId=x.ProductId,
                Picture=x.Picture,
                PictureTitle=x.PictureTitle,
                PictureAlt=x.PictureAlt,
            }).FirstOrDefault(x => x.Id == id); 
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query = _context.PropeProductPictures.Include(x=>x.Product).Select(x => new ProductPictureViewModel
            {
                Id = x.Id,
                Product=x.Product.Name,
                Picture=x.Picture,
                CreationDate=x.CreationDate.ToString(),
                ProductId=x.ProductId,
                IsRemoved=x.IsRemoved

            });

            if(searchModel.ProductId!=0)
                query=query.Where(x=>x.Id==searchModel.ProductId);

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
