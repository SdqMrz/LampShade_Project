using System.Collections.Generic;

namespace _01_LampShadeQuery.Contracts.Product
{
    public interface IProductQuery
    {
        List<ProductQueryModel> GetLatesProducts();
        ProductQueryModel GetProductDetails(string slug);
        List<ProductQueryModel> Search(string value);
    }
}
