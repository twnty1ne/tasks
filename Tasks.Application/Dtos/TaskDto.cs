using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Application.Dtos
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string TimeSpent { get; set; }
        public string Name { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public IEnumerable<TaskCommentDto> Comments { get; set; }

    }
}
