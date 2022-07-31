using System.Collections.Generic;
using _0_FrameWork.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product:EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public bool IsInStock { get; private set; }
        public double UnitPrice { get; private set; }
        public string Picture { get; private set; }
        public string PictureTitle { get; set; }
        public string PictureAlt { get; private set; }
        public string keyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public long CategoryId { get; private set; }

        public List<ProductPicture> ProductPictures { get; private set; }
        public ProductCategory Category { get; private set; }

        public Product(string name, string code, string shortDescription, string description, double unitPrice,
            string picture, string pictureTitle, string pictureAlt, string keyWords, string metaDescription,
            string slug, long categoryId)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            UnitPrice = unitPrice;
            Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            this.keyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;
            IsInStock = true;
        }
        public void Edit(string name, string code, string shortDescription, string description, double unitPrice,
            string picture, string pictureTitle, string pictureAlt, string keyWords, string metaDescription,
            string slug, long categoryId)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            UnitPrice = unitPrice;
            Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            this.keyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;
        }

        public void ExistInStock()
        {
            this.IsInStock = true;
        }
        public void NotExistInStock()
        {
            this.IsInStock = false;
        }
    }
}
