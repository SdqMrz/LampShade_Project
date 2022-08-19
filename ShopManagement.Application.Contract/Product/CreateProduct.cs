using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contract.ProductCategory;

namespace ShopManagement.Application.Contract.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Code { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        [MaxFileSize(3*1024*1024,ErrorMessage =ValidationMessage.MaxFileSize)]
        [FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" },ErrorMessage =ValidationMessage.MaxFileSize)]
        public IFormFile Picture { get; set; }
        public string PictureTitle { get; set; }
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string KeyWords { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Slug { get; set; }

        [Range(1,100000,ErrorMessage =ValidationMessage.IsRequired)]
        public long CategoryId { get; set; }
        public List<ProductCategoryViewModel> Categories { get; set; }
    }
}
