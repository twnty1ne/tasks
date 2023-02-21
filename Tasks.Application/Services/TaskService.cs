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
using Tasks.Application.Dtos;
using Tasks.Shared.Validation;

namespace Tasks.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<TaskEntity> _taskRepository;
        private readonly IRepository<TaskCommentEntity> _taskCommentRepository;
        private readonly IValidator<GetTasksRequest> _getTasksRequestValidator;

        public TaskService(IRepository<TaskEntity> taskRepository, IRepository<TaskCommentEntity> taskCommentRepository, IValidator<GetTasksRequest> getTasksRequestValidator)
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
            _taskCommentRepository = taskCommentRepository ?? throw new ArgumentNullException(nameof(taskCommentRepository));
            _getTasksRequestValidator = getTasksRequestValidator ?? throw new ArgumentNullException(nameof(getTasksRequestValidator));
        }

        public async Task CreateCommentsAsync(CreateCommentsRequest request)
        {
            var comments = request.Comments.Select(x => new TaskCommentEntity(request.TaskId, x.CommentType, x.Content));
            await _taskCommentRepository.AddRangeAsync(comments);
            await _taskCommentRepository.SaveChangesAsync();
        }

        public async Task CreateTaskAsync(CreateTaskRequest request)
        {
            var task = new TaskEntity(request.Name, request.ProjectId, request.StartDate, request.EndDate, request.Description);
            await _taskRepository.AddAsync(task);
            await _taskRepository.SaveChangesAsync();
        }

        public async Task DeleteCommentsAsync(DeleteCommentsRequest request)
        {
            var commentsToDelete = _taskCommentRepository.GetAll(x => x.TaskId == request.TaskId && request.Comments.Contains(x.Id));
            _taskCommentRepository.DeleteRange(commentsToDelete);
            await _taskCommentRepository.SaveChangesAsync();
        }

        public IEnumerable<TaskDto> GetTasks(GetTasksRequest getTasksRequest)
        {
            if (!_getTasksRequestValidator.Valid(getTasksRequest)) throw new InvalidRequestException();

            var taskEntities = _taskRepository
                .GetAll(x => x.ProjectId == getTasksRequest.ProjectId && x.CreateDate >= getTasksRequest.From && x.CreateDate <= getTasksRequest.To);

            return taskEntities.Select(x => new TaskDto
            {
                Id = x.Id,
                EndTime = x.EndDate,
                StartTime = x.StartDate,
                ProjectName = x.Project.Name,
                Name = x.Name,
                TimeSpent = x.CalculateSpentTime().ToString(@"hh\:mm"),
                Comments = x.Comments.Select(x => new TaskCommentDto
                {
                    Id = x.Id,
                    Content = x.Content,
                    CommentType = x.CommentType
                })

            });
        }
    }
}
