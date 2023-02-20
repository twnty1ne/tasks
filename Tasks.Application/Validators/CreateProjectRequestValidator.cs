using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Application.Requests;

namespace Tasks.Application.Validators
{
    public class CreateProjectRequestValidator : IValidator<CreateProjectRequest>
    {
        public bool Valid(CreateProjectRequest item)
        {
            return item != null && !string.IsNullOrWhiteSpace(item.Name);
        }
    }
}
