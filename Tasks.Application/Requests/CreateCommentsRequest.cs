using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Application.Requests
{
    public class CreateCommentsRequest
    {
        public Guid TaskId { get; set; }
        public IEnumerable<CreateCommentRequest> Comments { get; set; }

    }
}
