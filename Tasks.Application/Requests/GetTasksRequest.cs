using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Application.Requests
{
    public class GetTasksRequest
    {
        public Guid ProjectId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
