using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Application.Requests
{
    public class DeleteCommentsRequest
    {
        public Guid TaskId { get; set; }
        public IEnumerable<Guid> Comments { get; set; }
    }
}
