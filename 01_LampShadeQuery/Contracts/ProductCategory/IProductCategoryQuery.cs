using _01_LampShadeQuery.Contracts.Product;
using System.Collections.Generic;

namespace _01_LampShadeQuery.Contracts.ProductCategory
{
    public interface IProductCategoryQuery
    {
       ProductCategoryQueryModel GetCategoryWithProductsBy(string slug);
        List<ProductCategoryQueryModel> GetProductCategories();
        List<ProductCategoryQueryModel> GetCategoryWithProducs();
    }
}
