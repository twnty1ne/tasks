using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Exceptions;
using Tasks.Application.Requests;
using Tasks.Application.Validators;
using Tasks.Buisness;
using Tasks.DAL;

namespace Tasks.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<TaskEntity> _taskRepository;
        private readonly IRepository<TaskCommentEntity> _taskCommentRepository;
        private readonly IValidator<CreateTaskRequest> _createTaskRequestValidator;

        public TaskService(IRepository<TaskEntity> taskRepository, IRepository<TaskCommentEntity> taskCommentRepository, IValidator<CreateTaskRequest> createTaskRequestValidator)
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
            _taskCommentRepository = taskCommentRepository ?? throw new ArgumentNullException(nameof(taskCommentRepository));
            _createTaskRequestValidator = createTaskRequestValidator ?? throw new ArgumentNullException(nameof(createTaskRequestValidator));
        }

        public async Task CreateCommentsAsync(CreateCommentsRequest request)
        {
            var comments = request.Comments.Select(x => new TaskCommentEntity
            {
                Content = x.Content,
                TaskId = request.TaskId,
                CommentType = x.CommentType
            });
            await _taskCommentRepository.AddRangeAsync(comments);
            await _taskCommentRepository.SaveChangesAsync();
        }

        public async Task CreateTaskAsync(CreateTaskRequest request)
        {
            var valid = _createTaskRequestValidator.Valid(request);
            if (!valid) throw new InvalidRequestException();
            var task = new TaskEntity
            {
                Name = request.Name,
                EndDate = request.EndDate,
                StartDate = request.StartDate,
                CreateDate = DateTime.UtcNow,
                ProjectId = request.ProjectId,
                Comments = new List<TaskCommentEntity> 
                {
                    new TaskCommentEntity 
                    {
                        Content = request.Description,
                        CommentType = 1
                    }
                }
            };
            await _taskRepository.AddAsync(task);
            await _taskRepository.SaveChangesAsync();
        }

        public async Task DeleteCommentsAsync(DeleteCommentsRequest request)
        {
            var commentsToDelete = _taskCommentRepository.GetAll(x => x.TaskId == request.TaskId && request.Comments.Contains(x.Id));
            _taskCommentRepository.DeleteRange(commentsToDelete);
            await _taskCommentRepository.SaveChangesAsync();
        }

        public IEnumerable<TaskEntity> GetTasks(GetTasksRequest getTasksRequest)
        {
            return _taskRepository.GetAll(x => x.ProjectId == getTasksRequest.ProjectId && x.CreateDate >= getTasksRequest.From && x.CreateDate <= getTasksRequest.To);
        }
    }
}
