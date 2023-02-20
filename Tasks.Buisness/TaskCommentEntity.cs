using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Buisness
{
    public class TaskCommentEntity : Entity
    {
        public Guid TaskId { get; set; }
        public virtual TaskEntity Task { get; set; }
        public byte CommentType { get; set; }
        public byte[] Content { get; set; }
    }
}
