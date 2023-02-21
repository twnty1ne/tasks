using Tasks.Buisness;
using Tasks.Shared.Validation;

namespace Tasks.Buisness.Validators
{
    public class ProjectValidator : IValidator<ProjectEntity>
    {
        public bool Valid(ProjectEntity item)
        {
            return item != null && !string.IsNullOrWhiteSpace(item.Name);
        }
    }
}
