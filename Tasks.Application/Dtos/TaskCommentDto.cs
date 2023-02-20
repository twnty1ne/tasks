using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Application.Dtos
{
    public class TaskCommentDto
    {
        public Guid Id { get; set; }
        public byte[] Content { get; set; }
        public byte CommentType { get; set; }
    }
}
