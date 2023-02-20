using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Application.Requests;

namespace Tasks.Application.Validators
{
    public class CreateTaskRequestValidator : IValidator<CreateTaskRequest>
    {
        public bool Valid(CreateTaskRequest item)
        {
            return item != null 
                && !string.IsNullOrWhiteSpace(item.Name) 
                && item.ProjectId != Guid.Empty
                && (EndDateStartDateBothNull(item) || item.EndDate is null || StartDateLessOrEqualsToEndDate(item));
        }

        private bool EndDateStartDateBothNull(CreateTaskRequest item) 
        {
            return item.EndDate is null && item.StartDate is null;
        }

        private bool StartDateLessOrEqualsToEndDate(CreateTaskRequest item) 
        {
            return item.StartDate <= item.EndDate;
        }
    }
}
