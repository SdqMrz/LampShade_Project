using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contract.Article
{
    public class CreateArticle
    {
        [Required(ErrorMessage=ValidationMessage.IsRequired)]
        public string Title { get; set; }

        [Required(ErrorMessage=ValidationMessage.IsRequired)]
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage=ValidationMessage.IsRequired)]
        public string PublishDate { get; set; }

        public IFormFile Picture { get; set; }

        [Required(ErrorMessage=ValidationMessage.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage=ValidationMessage.IsRequired)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage=ValidationMessage.IsRequired)]
        public string MetaDescription { get; set; }
        public string KeyWords { get; set; }

        [Required(ErrorMessage=ValidationMessage.IsRequired)]
        public string Slug { get; set; }
        public string CanonicalAddress { get; set; }

        [Range(1,long.MaxValue,ErrorMessage=ValidationMessage.IsRequired)]
        public long CategoryId { get; set; }
    }
}
