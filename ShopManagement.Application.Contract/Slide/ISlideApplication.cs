using _0_FrameWork.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.Slide
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);
        OperationResult Edit(EditSlide command);
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
        OperationResult Remove(long id);
        OperationResult Restore(long id);
    }
}
