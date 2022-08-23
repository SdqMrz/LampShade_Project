using _0_FrameWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Comment
{
    public interface ICommentApplication
    {
        OperationResult Add(AddComment command);
        OperationResult Cancel(long id);
        OperationResult Confirm(long id);
        List<CommentViewModel> Search(CommentSearchModel searchModel);
    }
}
