using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Application.Contract.ArticleCategory
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string Name { get; set; }

        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string Description { get; set; }

        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public int OrderShow { get; set; }

        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string Slug { get; set; }

        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string KeyWords { get; set; }

        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string MetaDescription { get; set; }

        public string CanonicalAddress { get; set; }
    }
}
