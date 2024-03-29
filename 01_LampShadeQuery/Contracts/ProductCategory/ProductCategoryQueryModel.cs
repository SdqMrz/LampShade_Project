﻿using _0_FrameWork.Domain;
using _01_LampShadeQuery.Contracts.Product;
using System.Collections.Generic;

namespace _01_LampShadeQuery.Contracts.ProductCategory
{
    public class ProductCategoryQueryModel : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public string KeyWords { get; set; }
        public string MetaDescription { get; set; }
        public List<ProductQueryModel> Products { get; set; }
    }
}
