﻿using System.ComponentModel.DataAnnotations;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage=ValidationMessage.IsRequired)]
        public string Name { get; set; }
        public string Description { get; set; }

        [MaxFileSize(3*1024*1024, ErrorMessage=ValidationMessage.MaxFileSize)]
        [FileExtentionLimitation(new string[] {".jpeg",".jpg",".png"},ErrorMessage =ValidationMessage.FileExtentionMethod)]
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string KeyWords { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Slug { get; set; }
    }
}
