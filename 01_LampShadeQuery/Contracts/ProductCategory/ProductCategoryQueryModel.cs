using _0_FrameWork.Domain;

namespace _01_LampShadeQuery.Contracts.ProductCategory
{
    public class ProductCategoryQueryModel : EntityBase
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        //public List<Product> Products { get;  set; }
    }
}
