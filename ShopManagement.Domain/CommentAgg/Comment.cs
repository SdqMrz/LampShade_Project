using _0_FrameWork.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.CommentAgg
{
    public class Comment:EntityBase
    {
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCanceled { get; private set; }
        public long ProductId { get; private set; }
        public Product Product { get; private set; }

        public Comment(string email, string name, string message, long productId)
        {
            Email = email;
            Name = name;
            Message = message;
            ProductId = productId;
        }
        public void Cancel()
        {
            IsCanceled = true;
        }
        public void Confirm()
        {
            IsConfirmed = true;
        }
    }
}
