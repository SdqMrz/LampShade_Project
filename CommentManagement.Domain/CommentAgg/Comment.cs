using _0_FrameWork.Domain;
using System.Collections.Generic;

namespace CommentManagement.Domain.CommentAgg
{
    public class Comment : EntityBase
    {
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Website { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCanceled { get; private set; }
        public long OwnerRecordId { get; private set; }
        public int Type { get; private set; }
        public long ParentId { get; private set; }
        public Comment Parent { get; private set; }
        public List<Comment> Children { get; private set; }

        public Comment(string email, string name,string website, string message, long ownerRecordId,int type,long parentId)
        {
            Email = email;
            Name = name;
            Website = website;
            Message = message;
            OwnerRecordId= ownerRecordId;
            Type= type;
            ParentId= parentId;
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
