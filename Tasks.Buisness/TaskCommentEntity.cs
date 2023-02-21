using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Shared.Validation;

namespace Tasks.Buisness
{
    public class TaskCommentEntity : Entity
    {
        
        public TaskCommentEntity()
        {
        }

        public TaskCommentEntity(Guid taskId, byte commentType, byte[] content)
        {
            TaskId = taskId;
            CommentType = commentType;
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public TaskCommentEntity(byte commentType, byte[] content)
        {
            CommentType = commentType;
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public Guid TaskId { get; protected set; }
        public virtual TaskEntity Task { get; protected set; }
        public byte CommentType { get; protected set; }
        public byte[] Content { get; protected set; }
    }
}
