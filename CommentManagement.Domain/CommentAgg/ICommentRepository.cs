using _0_FrameWork.Domain;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Domain.CommentAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.CommentAgg
{
    public interface ICommentRepository:IRepository<long,Comment>
    {
        List<CommentViewModel> Search(CommentSearchModel searchModel);
    }
}
