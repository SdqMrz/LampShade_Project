using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using _0_FrameWork.Domain;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository:IRepository<long,ProductCategory>
    {
        EditProductCategory GetDetails(long id);
        string GetSlugBy(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        List<ProductCategoryViewModel> GetProductCategories();
    }
}
