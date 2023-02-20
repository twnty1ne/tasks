using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Requests;
using Tasks.Buisness;

namespace Tasks.Application.Services
{
    public interface ITaskService
    {
        Task CreateTaskAsync(CreateTaskRequest request);
        IEnumerable<TaskEntity> GetTasks(GetTasksRequest getTasksRequest);
        Task DeleteCommentsAsync(DeleteCommentsRequest request);
        Task CreateCommentsAsync(CreateCommentsRequest request);
    }
}
