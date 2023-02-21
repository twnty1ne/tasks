using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasks.Application.Exceptions;
using Tasks.Application.Requests;
using Tasks.Application.Services;
using Tasks.Buisness;
using System.Linq;
using Tasks.Application.Dtos;

namespace Tasks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTaskRequest request)
        {
            await _taskService.CreateTaskAsync(request);
            return Ok();
        }

        [HttpGet]
        public  IActionResult GetTasks([FromQuery] GetTasksRequest request)
        {
            var tasks = _taskService.GetTasks(request);
            return Ok(tasks);
        }

        [HttpDelete("{id}/comments")]
        public async Task<IActionResult> DeleteComments(Guid id, [FromBody] IEnumerable<Guid> comments)
        {
            var request = new DeleteCommentsRequest 
            {
                TaskId = id,
                Comments = comments
            };
            await _taskService.DeleteCommentsAsync(request);
            return Ok();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> CreateComments(Guid id, IEnumerable<CreateCommentRequest> comments)
        {
            var request = new CreateCommentsRequest
            {
                TaskId = id,
                Comments = comments
            };
            await _taskService.CreateCommentsAsync(request);
            return Ok();
        }
    }
}
