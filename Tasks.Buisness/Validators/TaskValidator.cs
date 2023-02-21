using System;
using Tasks.Shared.Validation;

namespace Tasks.Buisness.Validators
{
    public class TaskValidator : IValidator<TaskEntity>
    {
        public bool Valid(TaskEntity item)
        {
            return item != null 
                && !string.IsNullOrWhiteSpace(item.Name) 
                && item.ProjectId != Guid.Empty
                && (EndDateStartDateBothNull(item) || item.EndDate is null || StartDateLessOrEqualsToEndDate(item));
        }

        private bool EndDateStartDateBothNull(TaskEntity item) 
        {
            return item.EndDate is null && item.StartDate is null;
        }

        private bool StartDateLessOrEqualsToEndDate(TaskEntity item) 
        {
            return item.StartDate <= item.EndDate;
        }
    }
}
