using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Buisness.Exceptions;
using Tasks.Buisness.Validators;
using Tasks.Shared.Validation;

namespace Tasks.Buisness
{
    public class TaskEntity : Entity
    {
        private readonly IValidator<TaskEntity> _validator = new TaskValidator();
        public TaskEntity() 
        {
        }

        public TaskEntity(string name, Guid projectId, DateTime? startDate, DateTime? endDate, byte[] description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ProjectId = projectId;
            StartDate = startDate;
            EndDate = endDate;
            CreateDate = DateTime.UtcNow;
            Comments = new List<TaskCommentEntity> { new TaskCommentEntity(1, description) };
            if (!_validator.Valid(this)) throw new InvalidBuisnessException();
        }

        public TaskEntity(Guid id, string name, Guid projectId, DateTime? startDate, DateTime? endDate, byte[] description)
            : this(name, projectId, startDate, endDate, description)
        {
            Id = id;
        }

        public string Name { get; protected set; }
        public Guid ProjectId { get; protected set; }
        public virtual ProjectEntity Project { get; protected set; }
        public DateTime? StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }
        public DateTime CancelDate { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime UpdateDate { get; protected set; }
        public virtual IEnumerable<TaskCommentEntity> Comments { get; protected set; }

        public TimeSpan CalculateSpentTime() 
        {
            if (StartDate != null && EndDate is null) return DateTime.UtcNow - (DateTime)StartDate;
            return (DateTime)EndDate - (DateTime)StartDate;
        }
    }
}
