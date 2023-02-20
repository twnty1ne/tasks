using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tasks.Buisness;

namespace Tasks.DAL
{
    public class TaskRepository : Repository<TaskEntity>
    {
        public TaskRepository(TasksDbConext context) : base(context)
        {
        }
    }
}
