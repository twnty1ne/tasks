using Tasks.Application.Requests;
using Tasks.Shared.Validation;

namespace Tasks.Application.Validators
{
    public class GetTasksRequestValidator : IValidator<GetTasksRequest>
    {
        public bool Valid(GetTasksRequest item)
        {
            return item != null && item.To >= item.From;
        }
    }
}
