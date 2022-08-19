using _01_LampShadeQuery.Contracts.Product;
using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class LatesProductsViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public LatesProductsViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var products = _productQuery.GetLatesProducts();
            return View(products);
        }
    }
}
