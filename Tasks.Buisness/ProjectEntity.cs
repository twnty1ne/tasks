using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Buisness
{
    public class ProjectEntity : Entity
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual IEnumerable<TaskEntity> Tasks { get; set; }

    }
}
