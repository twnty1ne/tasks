using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Buisness;

namespace Tasks.DAL
{
    public class ProjectRepository : Repository<ProjectEntity>
    {
        public ProjectRepository(TasksDbConext context) : base(context)
        {
        }
    }
}
