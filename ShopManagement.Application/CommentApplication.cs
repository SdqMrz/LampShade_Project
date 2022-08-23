using _0_FrameWork.Application;
using ShopManagement.Application.Contract.Comment;
using ShopManagement.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public OperationResult Add(AddComment command)
        {
            var operation=new OperationResult();

            var comment = new Comment(command.Email, command.Name, command.Message, command.ProductId);

            _commentRepository.Create(comment);
            _commentRepository.SaveChanges();
            return operation.Successed();
        }

        public OperationResult Cancel(long id)
        {
            var operation = new OperationResult();

            var comment = _commentRepository.Get(id);
            if(comment == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            comment.Cancel();
            _commentRepository.SaveChanges();
            return operation.Successed();
        }

        public OperationResult Confirm(long id)
        {
            var operation = new OperationResult();

            var comment = _commentRepository.Get(id);
            if (comment == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            comment.Confirm();
            _commentRepository.SaveChanges();
            return operation.Successed();
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            return _commentRepository.Search(searchModel);
        }
    }
}
