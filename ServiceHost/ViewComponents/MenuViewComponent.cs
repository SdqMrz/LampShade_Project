using _01_LampShadeQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public MenuViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
