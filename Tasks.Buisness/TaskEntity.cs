using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Buisness
{
    public class TaskEntity : Entity
    {
        public string Name { get; set; }
        public Guid ProjectId { get; set; }
        public virtual ProjectEntity Project { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CancelDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual IEnumerable<TaskCommentEntity> Comments { get; set; }

        public TimeSpan CalculateSpentTime() 
        {
            if (StartDate != null && EndDate is null) return DateTime.UtcNow - (DateTime)StartDate;
            return (DateTime)EndDate - (DateTime)StartDate;
        }
    }
}
