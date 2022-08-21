using _0_FrameWork.Application;
using _0_FrameWork.Domain;
using _0_FrameWork.Infrastructure;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context):base(context)
        {
            _context = context;
        }
        
        public EditSlide GetDetails(long id)
        {
           return _context.Slides.Where(x => x.Id == id).Select(x => new EditSlide
           {
           Id = id, 
           PictureAlt = x.PictureAlt,
           PictureTitle = x.PictureTitle,
           Heading = x.Heading,
           Title = x.Title,
           BtnText = x.BtnText,
           Link=x.Link,
           Text = x.Text
           }).FirstOrDefault();
        }

        public List<SlideViewModel> GetList()
        {
            
            return _context.Slides.Select(x=> new SlideViewModel 
            {
            Picture = x.Picture,
            Heading = x.Heading,
            Title= x.Title,
            Id = x.Id,
            CreationDate = x.CreationDate.ToFarsi(),
            IsRemoved = x.IsRemoved
            }).OrderByDescending(x=>x.Id).ToList();
        }

    }
}
