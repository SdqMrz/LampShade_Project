using _0_FrameWork.Application;
using _0_FrameWork.Domain;
using ShopManagement.Application.Contract.Slide;
using System.Collections.Generic;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository : IRepository<long, Slide>
    {
        EditSlide GetDetails(long id);

        List<SlideViewModel> GetList();
    }

}
