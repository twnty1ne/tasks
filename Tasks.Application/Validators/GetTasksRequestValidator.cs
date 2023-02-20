using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Application.Requests;

namespace Tasks.Application.Validators
{
    public class GetTasksRequestValidator : IValidator<GetTasksRequest>
    {
        public bool Valid(GetTasksRequest item)
        {
            return item != null && item.To <= item.From;
        }
    }
}
