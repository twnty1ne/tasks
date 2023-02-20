using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Buisness;

namespace Tasks.DAL
{
    public class TaskCommentRepository : Repository<TaskCommentEntity>
    {
        public TaskCommentRepository(TasksDbConext context) : base(context)
        {
        }
    }
}
